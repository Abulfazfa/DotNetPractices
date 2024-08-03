using AirlineRabbitMQ.API.Models;
using AirlineRabbitMQ.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineRabbitMQ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMessageProducer _messageProducer;

        // In-Memory db
        public static readonly List<Booking> bookings = new();

        public BookingController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking) 
        {
            if (newBooking == null && !ModelState.IsValid) return BadRequest();
            
            bookings.Add(newBooking);

            _messageProducer.SendingMessage<Booking>(newBooking);

            return Ok();
        }
    }
}
