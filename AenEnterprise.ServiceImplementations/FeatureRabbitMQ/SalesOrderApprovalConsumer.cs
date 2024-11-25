using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
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
                HostName = "localhost", // Replace with your RabbitMQ server's hostname
                UserName = "nuruddin",  // Replace with your RabbitMQ username
                Password = "1234",      // Replace with your RabbitMQ password
                VirtualHost = "/"       // Replace with your RabbitMQ virtual host, if applicable
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            // Declare the queue
            _channel.QueueDeclare(
                queue: "SalesOrderApprovalQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public void StartListening()
        {
            var consumer = new EventingBasicConsumer(_channel);

            // Handle message reception
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[x] Received message: {message}");

                // Send message to all connected SignalR clients
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            };

            // Consume messages from the queue
            _channel.BasicConsume(
                queue: "SalesOrderApprovalQueue",
                autoAck: true,
                consumer: consumer);

            Console.WriteLine(" [*] Waiting for messages.");
        }
    }
}
