using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
{
    public class RabbitMQPublisher:IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost", // or your RabbitMQ server's hostname
                UserName = "nuruddin",
                Password = "1234",
                VirtualHost = "/" // Use the correct virtual host
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "SalesOrderApprovalQueue",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
        }
        public void PublishMessage(string queueName, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            Console.WriteLine($"[x] Sent: {message}");
        }
        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}
