using System;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Newtonsoft.Json;

public class NewProductQueue {
    IConnectionFactory _Factory;

    public NewProductQueue()
    {
        _Factory = new ConnectionFactory(new Uri("tcp://localhost:61616"));
    }

    public void SendProduct(Product productToSend) {
        using(var connection = _Factory.CreateConnection()) {
            using(var session = connection.CreateSession() ) {
                var targetQueue = session.GetQueue("products");
                var productMessage = session.CreateTextMessage(JsonConvert.SerializeObject(productToSend));
                var producer = session.CreateProducer(targetQueue);
                producer.Send(productMessage);
            }
        }
        
    }
}