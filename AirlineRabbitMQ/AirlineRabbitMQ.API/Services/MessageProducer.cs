using AirlineRabbitMQ.API.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace AirlineRabbitMQ.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        private readonly RabbitMQConnectionManager _connectionManager;

        // Inject the connection manager
        public MessageProducer(RabbitMQConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void SendingMessage<T>(T message)
        {
            // Use a channel from the shared connection
            using var channel = _connectionManager.CreateChannel();

            // Ensure queue properties are consistent
            channel.QueueDeclare("bookings", durable: true, exclusive: false, autoDelete: false);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish(exchange: "", routingKey: "bookings", body: body);
        }
    }
}
