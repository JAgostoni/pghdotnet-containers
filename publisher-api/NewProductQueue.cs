using System;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;

public class NewProductQueue {
    IConnectionFactory _Factory;

    public NewProductQueue()
    {

        var host = Environment.GetEnvironmentVariable("ACTIVE_MQ_HOST") ?? "localhost";

        Console.WriteLine($"ActiveMQ Host: {host}");
        _Factory = new ConnectionFactory(new Uri($"tcp://{host}:61616"));
    }

    public void SendProduct(Product productToSend) {
        using(var connection = _Factory.CreateConnection()) {
            using(var session = connection.CreateSession() ) {
                var target = session.GetTopic("VirtualTopic.product-updates");
                var productMessage = session.CreateTextMessage(JsonConvert.SerializeObject(productToSend));
                var producer = session.CreateProducer(target);
                producer.Send(productMessage);
            }
        }
        
    }
}