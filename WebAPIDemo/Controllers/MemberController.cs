using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Request;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Services.Services;
using Microsoft.AspNetCore.Authorization;
namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController(IMemberService memberService, IMapper mapper) : Controller
    {
        [HttpGet("GetAllMembers")]
        public async Task<ActionResult> Get()
        {
            var members = await memberService.GetAllMembers();
            //var membersRequest = mapper.Map<MemberRequest>(members);
            return Ok(members);
        }

        [HttpDelete("deleteMember")]
        public async Task<bool> RemoveMember(int id)
        {
            var member = await memberService.GetMemberById(id);
            if (member == null)
            {
                BadRequest($"Member Id: {id} not Found");
                return false;
            }
            else
            {
                await memberService.DeleteMember(id);
                return true;
            }
        }

        [HttpPost("addMember")]

        public async Task<ActionResult> addMember(MemberRequest memberRequest)
        {
            var member = mapper.Map<Member>(memberRequest);
            await memberService.Add(member);
            return Ok(member);
        }
        [HttpPost("UpdateMember")]

        public async Task<ActionResult<Member?>> UpdateMember(MemberRequest memberRequest, int memberId)
        {
            if (await memberService.GetMemberById(memberId) == null)
            {
                return BadRequest($"{memberId} Not exist");
            }
            var newMember = mapper.Map<Member>(memberRequest);
            newMember.Id = memberId;
            await memberService.Update(newMember);
            return Ok(newMember);
        }
    }
}
