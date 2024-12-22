using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

Console.WriteLine("Hello to ticketing service");

// Setup connection factory with RabbitMQ server details
var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "password",
    VirtualHost = "/"
};

try
{
    // Create a connection to RabbitMQ
    using var conn = factory.CreateConnection();
    // Create a channel from the connection
    using var channel = conn.CreateModel();

    // Declare the queue with correct properties (ensure the name and settings match the producer)
    channel.QueueDeclare(queue: "bookings", durable: true, exclusive: false, autoDelete: false);

    // Create a consumer that listens on the channel
    var consumer = new EventingBasicConsumer(channel);

    // Set up the event handler to process received messages
    consumer.Received += (sender, args) =>
    {
        try
        {
            var body = args.Body.ToArray(); // Get the message body as a byte array
            var message = Encoding.UTF8.GetString(body); // Convert the byte array to a string
            Console.WriteLine($"A message has been received - {message}"); // Print the message
        }
        catch (Exception ex)
        {
            // Handle any message processing errors
            Console.WriteLine($"Error processing message: {ex.Message}");
        }
    };

    // Start consuming messages from the declared queue
    channel.BasicConsume(queue: "bookings", autoAck: true, consumer: consumer);

    Console.WriteLine("Press [enter] to exit.");
    Console.ReadLine(); // Keep the console open to receive messages
}
catch (Exception ex)
{
    // Handle any connection or setup errors
    Console.WriteLine($"Error: {ex.Message}");
}
