﻿using System;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;

namespace products_receiver
{
    class Program
    {
        
        static ManualResetEvent _SIGTERM = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            AssemblyLoadContext.Default.Unloading += obj => _SIGTERM.Set();

            var host = Environment.GetEnvironmentVariable("ACTIVE_MQ_HOST") ?? "localhost";
            Console.WriteLine($"ActiveMQ Host: {host}");

                var factory = new ConnectionFactory(new Uri($"tcp://{host}:61616"));
                var connection = factory.CreateConnection();
                var session = connection.CreateSession();
                var target = session.GetTopic("product-updates");
                var consumer = session.CreateConsumer(target, null);
                consumer.Listener += message => {
                    var productJson = (message as ITextMessage)?.Text;
                    if(!String.IsNullOrEmpty(productJson)) {
                        try {
                            var product = JsonConvert.DeserializeObject<Product>(productJson);
                            Console.WriteLine($"Received Product ID: {product.Id}");
                        } catch {}
                    }
                };
                connection.Start();
            

            Console.WriteLine("Press CTRL-C to close");
            _SIGTERM.WaitOne();
    
        }
    }
}