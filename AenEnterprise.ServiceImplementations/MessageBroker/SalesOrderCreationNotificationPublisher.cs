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
    public class SalesOrderCreationNotificationPublisher : IMessagePublish
    {
        private readonly IModel _channel;

        public SalesOrderCreationNotificationPublisher()
        {
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
                queue: "SalesOrderCreatedQueue", // The queue where messages will be sent
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public async Task PublishSalesOrderCreatedMessage(SalesOrder salesOrder)
        {
            var message = new SalesOrderCreatedMessage
            {
                SalesOrderId = salesOrder.Id,
                CustomerName = salesOrder.Customer.Name,
                OrderedDate = salesOrder.OrderedDate.ToString("yyyy-MM-dd"),
                SalesOrderNo = salesOrder.SalesOrderNo
            };

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            _channel.BasicPublish(
                exchange: "",
                routingKey: "SalesOrderCreatedQueue",
                basicProperties: null,
                body: body);

            Console.WriteLine($" [x] Sent '{message.SalesOrderNo}' message to queue.");
            await Task.CompletedTask;
        }
    }
}
