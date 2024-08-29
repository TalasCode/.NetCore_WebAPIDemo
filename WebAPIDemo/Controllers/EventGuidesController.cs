using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Request;
using WebAPIDemo.Core.Models;
namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuidesController(IEventGuidesService eventGuidesService , IMapper mapper , IEventService eventService) :Controller
    {
        [HttpGet("GetAllEventGuides")]

        public async Task<ActionResult<GuideDTO>> getAllEventGuides(int eventId)
        {
            if (eventService.GetEventById == null)
            {
                return BadRequest("Event not Exist");
            }
            var guides = await eventGuidesService.GetEventGuides(eventId);
            return Ok(guides);
        }
        [HttpPost("AddEventGuide")]
        public async Task<IActionResult> AddEventGuide(EventGuideRequest eventGuideRequest)
        {
            if (eventGuideRequest.EventId.HasValue && eventService.GetEventById(eventGuideRequest.EventId.Value) == null)
            {
                return BadRequest("Event not Exist");
            }
            EventGuide eventGuide = mapper.Map<EventGuide>(eventGuideRequest);
            await eventGuidesService.AddEventGuide(eventGuide);
            return Ok(eventGuide);
        }
        [HttpDelete("deleteEventGuide")]
        public async Task<IActionResult> DeleteEventGuide(EventGuideRequest eventGuideRequest)
        {
            //Make sure if the guide exist
            if (eventGuideRequest.EventId.HasValue && eventService.GetEventById(eventGuideRequest.EventId.Value) == null)
            {
                return BadRequest("Event not Exist");
            }
            EventGuide eventGuide = mapper.Map<EventGuide>(eventGuideRequest);
            await eventGuidesService.RemoveEventGuide(eventGuide);
            return Ok(eventGuide);
        }
    }
}
