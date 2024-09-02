using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Request;
using WebAPIDemo.Services.Services;
using WebAPIDemo.Services.Services.IServices;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GuideController(IGuideService guideService , IMapper mapper):Controller
    {
        [HttpGet("GetAllGuides")]
        public async Task<ActionResult> Get()
        {
            var guides = await guideService.GetAllGuides();
          
            return Ok(guides);
        }

        [HttpDelete("deleteGuide")]
        public async Task<bool> RemoveGuide(int id)
        {
            var guide = await guideService.GetGuideById(id);
            if (guide == null)
            {
                BadRequest($"Member Id: {id} not Found");
                return false;
            }
            else
            {
                await guideService.Remove(guide);
                return true;
            }
        }

        [HttpPost("addGuide")]

        public async Task<ActionResult> addMember(GuideRequest guideRequest)
        {
            var guide = mapper.Map<Guide>(guideRequest);
            await guideService.Add(guide);
            return Ok(guide);
        }

        [HttpPost("UpdateGuide")]

        public async Task<ActionResult<Guide?>> UpdateGuide(GuideRequest guideRequest, int guideId)
        {
            if (await guideService.GetGuideById(guideId) == null)
            {
                return BadRequest($"{guideId} Not exist");
            }
            var newguide = mapper.Map<Guide>(guideRequest);
            newguide.Id = guideId;
            await guideService.Update(newguide);
            return Ok(newguide);
        }
    }
}

