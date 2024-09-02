using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Request;
using WebAPIDemo.Services.Services;
using WebAPIDemo.Services.Services.IServices;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventMembersController(IMapper mapper , IEventMembersService eventMembersService , IEventService eventService):Controller
    {
        [HttpGet("GetAllEventMembers")]

        public async Task<ActionResult<MemberDTO>> getAllEventMembers(int eventId)
        {
            if (eventService.GetEventById == null)
            {
                return BadRequest("Event not Exist");
            }
            var Members = await eventMembersService.GetEventMembers(eventId);
            return Ok(Members);
        }
        [HttpPost("AddEventMember")]
        public async Task<IActionResult> AddEventGuide(EventMemberRequest eventMemberRequest)
        {
            if (eventMemberRequest.EventId.HasValue)
            {
                var eventEntity = await eventService.GetEventById(eventMemberRequest.EventId.Value);
                if (eventEntity == null)
                {
                    return BadRequest("Event does not exist");
                }
            }

            EventMember eventMember = mapper.Map<EventMember>(eventMemberRequest);
            await eventMembersService.AddEventMember(eventMember);
            return Ok(eventMember);
        }
        [HttpDelete("deleteEventMember")]
        public async Task<IActionResult> DeleteEventGuide(EventMemberRequest eventMemberRequest)
        {
            //Make sure if the guide exist
            if (eventMemberRequest.EventId.HasValue && await eventService.GetEventById(eventMemberRequest.EventId.Value) == null)
            {
                return BadRequest("Event not Exist");
            }
            EventMember eventMember = mapper.Map<EventMember>(eventMemberRequest);
            await eventMembersService.RemoveEventMember(eventMember);
            return Ok(eventMember);
        }
    }
}
