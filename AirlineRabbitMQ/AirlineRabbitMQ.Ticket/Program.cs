using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hello to ticketing service");

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "password",
    VirtualHost = "/"
};

var conn = factory.CreateConnection();
using var channel = conn.CreateModel();

channel.QueueDeclare("booking", durable: true, exclusive: true);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();

    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"A message has been recieved - {message}");
};

channel.BasicConsume("bookings", true, consumer);

Console.ReadLine();