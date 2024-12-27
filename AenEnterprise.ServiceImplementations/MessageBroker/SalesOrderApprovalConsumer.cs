using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class SalesOrderApprovalConsumer
    {
        private readonly IModel _channel;
        private readonly IHubContext<NotificationHub> _hubContext;

        public SalesOrderApprovalConsumer(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;

            // Set up RabbitMQ connection and channel
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "nuruddin",
                Password = "1234",
                VirtualHost = "/"
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(
                queue: "SalesOrderCreatedQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void StartListening()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] Received message: {message}");

                // Process the message and notify clients
                var salesOrderMessage = JsonConvert.DeserializeObject<SalesOrderCreatedMessage>(message);
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", salesOrderMessage);

                // Acknowledge the message
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(
                queue: "SalesOrderCreatedQueue",
                autoAck: false, // Set to false if you want manual acknowledgment
                consumer: consumer);

            Console.WriteLine(" [*] Waiting for messages.");
        }
    }
}
