using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class RabbitMQListenerService : BackgroundService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<RabbitMQListenerService> _logger;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQListenerService(IHubContext<NotificationHub> hubContext, ILogger<RabbitMQListenerService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;

            // Initialize RabbitMQ connection and channel
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "nuruddin",
                Password = "1234",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            // Declare the queue
            _channel.QueueDeclare(queue: "sales_order_created_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            // Set up the consumer
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, e) =>
            {
                if (stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Background service is stopping.");
                    return;
                }

                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var salesOrder = JsonConvert.DeserializeObject<SalesOrder>(message);

                // Notify all connected clients
                await _hubContext.Clients.All.SendAsync("SalesOrderCreatedNotification", salesOrder);

                _logger.LogInformation("Sales Order Created notification sent.");
            };

            // Start consuming messages
            _channel.BasicConsume(queue: "sales_order_created_queue", autoAck: true, consumer: consumer);

            _logger.LogInformation("RabbitMQ Listener Service is running.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("RabbitMQ Listener Service is stopping.");

            // Clean up resources
            _channel.Close();
            _connection.Close();

            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }
    }


}
