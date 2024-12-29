using AenEnterprise.DomainModel.AccountsAndFinance.AccountReceivable.SalesManagement;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations.MessageBroker
{
    public class MessagePublish : IMessagePublish, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessagePublish()
        {
            // Configure and create a connection factory
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "nuruddin",
                Password = "1234",
                VirtualHost = "/"
            };

            // Create the connection and channel
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task PublishSalesOrderCreatedMessage(SalesOrder salesOrder)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var message = JsonConvert.SerializeObject(salesOrder, settings);
            var body = Encoding.UTF8.GetBytes(message);

            // Declare the queue and publish the message
            _channel.QueueDeclare(queue: "sales_order_created_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.BasicPublish(exchange: "", routingKey: "sales_order_created_queue", basicProperties: null, body: body);

            // Log the event
            Console.WriteLine($"Published sales order with ID {salesOrder.Id} to the queue.");
        }

        // Dispose resources to avoid leaks
        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }


}
