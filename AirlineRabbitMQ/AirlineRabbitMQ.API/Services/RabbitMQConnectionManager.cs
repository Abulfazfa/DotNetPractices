using RabbitMQ.Client;
using System;

namespace AirlineRabbitMQ.API.Services
{
    public class RabbitMQConnectionManager : IDisposable
    {
        private readonly IConnection _connection;

        public RabbitMQConnectionManager()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "password",
                VirtualHost = "/"
            };

            // Establish a single connection
            _connection = factory.CreateConnection();
        }

        // Provides a channel for each operation
        public IModel CreateChannel()
        {
            return _connection.CreateModel();
        }

        // Properly dispose of the connection
        public void Dispose()
        {
            if (_connection != null && _connection.IsOpen)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
