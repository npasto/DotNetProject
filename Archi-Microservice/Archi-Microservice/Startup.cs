using System;
using System.Threading;
using Microsoft.Owin;
using Owin;

using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using NetMQ;
using NetMQ.Sockets;
using System.Globalization;
using MicroServicesDTOs;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(Archi_Microservice.Startup))]
namespace Archi_Microservice
{
    public class Startup
    {
        //variable pour revoir l'évenement de fermeture du srv Owin
        static bool stopRequested = false;
        public void Configuration(IAppBuilder app)
        {
            //code pour réagir à la fermeture de l'evt OWIN et mettre stopRequested = true
            var context = new OwinContext(app.Properties);
            var token = context.Get<CancellationToken>("host.OnAppDisposing");
            if (token != CancellationToken.None)
            {
                token.Register(() =>
                {
                    stopRequested = true;
                });
            }
            //enrolement de la lib signalR
            app.MapSignalR();
            //test :
            //Thread t = new Thread(new ThreadStart(testNotifyAllWebClients));
                        //lance dans un thread la méthode d'écoute des message ZMQ
            Thread t = new Thread(new ThreadStart(processZmqStockMessages));
            t.Start();
        }

    

        //topic des msg ecoutés sur ZMQ
        const String marketPlaceTopic = "NASDAQ";
        /// <summary>
        /// méthode qui reçoit les messages ZMQ du server de stock et les broadcaste via SignalR à la UI
        /// </summary>
        private void processZmqStockMessages()
        {
            Console.WriteLine("Loggin Stocks data form {0}...", marketPlaceTopic);
            using (var subscriber = new SubscriberSocket())
            {
                #region instanciation du HUB signalR 
                var StocksHub = GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<StocksHubs>();
                #endregion
                #region abonnement à la file ZMQ sur le topic NASDAQ
                subscriber.Connect("tcp://127.0.0.1:5556");
                //choix du topic !!
                subscriber.Subscribe(marketPlaceTopic.ToString(CultureInfo.InvariantCulture));
                #endregion
                string msgTopic;
                string stockAsJson;
                StockVariation sv;
                while (!stopRequested)
                {
                    //recoit et traite le msg ZMQ
                    string results = subscriber.ReceiveFrameString();

                    // format "[topic {stock en JSON}]
                    string[] split = results.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    msgTopic = (split[0] as string).ToUpper();
                    if (marketPlaceTopic != msgTopic)
                    {
                        String msg = $"Received message for unexpected marketPlaceTopic: {msgTopic} (expected {marketPlaceTopic})";
                        Console.WriteLine(msg);
                        //mieux faire en production !!!
                        throw new Exception(msg);
                    }
                    //ajouter try/catch
                    stockAsJson = split[1];
                    sv = JsonConvert.DeserializeObject<StockVariation>(stockAsJson);
                    Console.WriteLine("Log: {0}", stockAsJson);

                    //This broadcasts le nouveau stock à tous les clients connectés 
                    StocksHub.Clients.All.broadcastMessage(sv.name, $"{sv.variation}%");
                }//while
            }

        }//processZmqStockMessages

        #region test en dur de notification des clients
        private void testNotifyAllWebClients()
        {
            while (true)
            {
                var StocksHub = GlobalHost.DependencyResolver.Resolve<IConnectionManager>().GetHubContext<StocksHubs>();

                //This broadcasts the message to all the clients 
                StocksHub.Clients.All.broadcastMessage("stock", "test");

                Thread.Sleep(2000);
            }

        }
        #endregion

    }//class Startup
}
