﻿namespace AirlineRabbitMQ.API.Services.Interfaces
{
    public interface IMessageProducer
    {
        public void SendingMessage<T>(T message);
    }
}
