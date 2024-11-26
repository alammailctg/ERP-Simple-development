using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
 
using RabbitMQ.Client.Exceptions;

namespace AenEnterprise.ServiceImplementations.FeatureRabbitMQ
{
    public class RabbitMQPublisher : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost", // or specify the IP address
                    UserName = "nuruddin",
                    Password = "1234",
                    VirtualHost = "/",
                    Port = 5672,
                    AutomaticRecoveryEnabled = true,
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                    RequestedConnectionTimeout = TimeSpan.FromSeconds(30), // Increase timeout if needed
                };

                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: "SalesOrderApprovalQueue",
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);

                Console.WriteLine("RabbitMQ connection established successfully.");
            }
            catch (BrokerUnreachableException ex)
            {
                Console.WriteLine($"RabbitMQ broker unreachable: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing RabbitMQ connection: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Publishes a message to the specified RabbitMQ queue.
        /// </summary>
        /// <param name="queueName">The name of the RabbitMQ queue.</param>
        /// <param name="message">The message to publish.</param>
        public void PublishMessage(string queueName, string message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: "",
                                      routingKey: queueName,
                                      basicProperties: null,
                                      body: body);

                Console.WriteLine($"[x] Sent: {message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error publishing message to RabbitMQ: {ex.Message}");
                // Optional: Implement retry logic here
            }
        }

        /// <summary>
        /// Disposes of the RabbitMQ connection and channel.
        /// </summary>
        public void Dispose()
        {
            try
            {
                _channel?.Close();
                _connection?.Close();
                Console.WriteLine("RabbitMQ connection and channel closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during RabbitMQ cleanup: {ex.Message}");
            }
        }
    }
}

