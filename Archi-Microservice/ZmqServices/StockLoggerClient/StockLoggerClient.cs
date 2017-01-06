using System;
using System.Globalization;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;
using System.IO;
using MicroServicesDTOs;

namespace StockLoggerClient
{
    internal static class StockLoggerClient
    {
        const String marketPlaceTopic = MicroServicesSharedConfigurations.marketPlaceNasdaqTopic;
        const String pubSrvAddress = MicroServicesSharedConfigurations.marketZmqTcpStream;
        const string fileStorageAddress = MicroServicesSharedConfigurations.stockLoggerFilePath;
        private static void Main()
        {
            bool stopRequested = false;
            Console.Title = $"{marketPlaceTopic} NetMQ StockLoggerClient";


            Console.WriteLine("Loggin Stocks data from address:{0}", pubSrvAddress);
            Console.WriteLine("with topic :{0}", marketPlaceTopic);
            Console.WriteLine("store in:{0}", fileStorageAddress);

            // Wire up the CTRL+C handler
            Console.CancelKeyPress += (sender, e) => stopRequested = true;

            using (var subscriber = new SubscriberSocket())
            {
                using (StreamWriter fileSw = new StreamWriter(fileStorageAddress))
                {
                    subscriber.Connect(pubSrvAddress);
                    //choix du topic !!
                    subscriber.Subscribe(marketPlaceTopic.ToString(CultureInfo.InvariantCulture));

                    string msgTopic;
                    string stockAsJson;
                    while (!stopRequested)
                    {
                        string results = subscriber.ReceiveFrameString();

                        // format "[topic {stock en JSON}]
                        string[] split = results.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        msgTopic = (split[0] as string).ToUpper();
                        if (marketPlaceTopic != msgTopic)
                        {
                            String msg = $"Received message for unexpected marketPlaceTopic: {msgTopic} (expected {marketPlaceTopic})";
                            Console.WriteLine(msg);
                            throw new Exception(msg);
                        }
                        //ajouter try/catch
                        stockAsJson = split[1];

                        Console.WriteLine("Log: {0}", stockAsJson);
                        fileSw.WriteLine(stockAsJson);
                        fileSw.Flush();
                    }//while
                    fileSw.Close();
                }//file
            }//sub socket
            //Thread.Sleep(3000);
        }
    }
}