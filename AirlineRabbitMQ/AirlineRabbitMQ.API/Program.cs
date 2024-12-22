using AirlineRabbitMQ.API.Services;
using AirlineRabbitMQ.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register RabbitMQConnectionManager as a singleton
builder.Services.AddSingleton<RabbitMQConnectionManager>();

// Register MessageProducer as a singleton, using the connection manager
builder.Services.AddSingleton<IMessageProducer, MessageProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
