using System;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using MicroServicesDTOs;

/// <summary>
/// Classe de simulation des stocks et publication via ZQM
/// </summary>
namespace StockRealTime
{
    internal static class StockRealTime
    {
        const String marketPlace = MicroServicesSharedConfigurations.marketPlaceNasdaqTopic;

        static readonly List<string> names = new List<string> { "AAPL", "GOOG", "YHOO", "TSLA", "INTC", "AMZN", "BIDU", "ORCL", "MSFT", "NVDA", "GME", "NFLX" };

        static readonly Random rng = new Random((int)System.DateTime.Now.Ticks);
        private static void Main()
        {
            Console.Title = "NetMQ Stock Server";

            bool stopRequested = false;

            // Wire up the CTRL+C handler
            Console.CancelKeyPress += (sender, e) => stopRequested = true;

            Console.WriteLine($"Publishing Stock values updates on {MicroServicesSharedConfigurations.marketZmqTcpStream} with topic {marketPlace}...");

            using (var publisher = new PublisherSocket())
            {
                publisher.Bind(MicroServicesSharedConfigurations.marketZmqTcpStream);

                StockVariation s;
                String zmqMessage;

                while (!stopRequested)
                {
                    s = new StockVariation(pickStockName, rng.Next(-99, 99));
                    zmqMessage = $"{marketPlace} {JsonConvert.SerializeObject(s)}";
                    Console.WriteLine($"sending : {zmqMessage}");
                    publisher.SendFrame(zmqMessage);
                    Thread.Sleep(2000);
                }
            }
        }


        static private string pickStockName
        {
            get { return names[rng.Next(names.Count)]; }
        }
    }//srv class

   



}
