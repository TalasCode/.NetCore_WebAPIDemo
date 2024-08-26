using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Request;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Services.Services;
namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(IEventService eventService , IMapper mapper , IUserService userService): Controller
    {
        
        [HttpGet("GetAllEvents")]
        public async Task<ActionResult> Get()
        {
            var events = await eventService.GetAllEvents();
            return Ok(events);
        }
        [HttpPost("CreateEvent")]
        public async Task<ActionResult<Event?>> CreateEvent(EventRequest eventRequest)
        {
            var user = await userService.getUserById(eventRequest.UserId.Value);
            if (user == null)
            {
                return BadRequest($"User with ID {eventRequest.UserId} does not exist.");
            }
            var newEvent = mapper.Map<Event>(eventRequest);
            await eventService.createEvent(newEvent);
            return Ok(newEvent);
        }

        [HttpPost("/UpdateEvent")]

        public async Task<ActionResult<Event?>> UpdateEvent(EventRequest eventRequest , int eventId)
        {
            if(eventService.GetEventById(eventId) == null)
            {
                return BadRequest($"{eventId} Not exist");
            }
            var newEvent = mapper.Map<Event>(eventRequest);
           await eventService.updateEvent(newEvent);
            return Ok(eventRequest);
        }

        [HttpGet("GetEventByUser")]
        public async Task<EventDTO> GetEventsByUser(int userId)
        {
            var events = await eventService.GetEventByUser(userId);
            var eventDTO = mapper.Map<EventDTO>(events);
            return eventDTO;
        }
    }
}
