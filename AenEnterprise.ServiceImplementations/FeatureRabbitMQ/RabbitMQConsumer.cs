using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
{
    public class RabbitMQConsumer:BackgroundService
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "salesOrderQueue";

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Deserialize the message
                var approvalMessage = JsonSerializer.Deserialize<SalesOrderApprovalMessage>(message);

                // Process the approval message (e.g., log it, send an email, etc.)
                Console.WriteLine($"Received Approval Request for SalesOrderId: {approvalMessage.SalesOrderId}, Status: {approvalMessage.Status}");

                // You can call an external service or update the database here
            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
