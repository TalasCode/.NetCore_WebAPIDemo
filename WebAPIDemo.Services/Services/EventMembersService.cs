using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services.IServices;
namespace WebAPIDemo.Services.Services
{
    public class EventMembersService(IUnitOfWork unitOfWork): IEventMembersService
    {
        public async Task<List<MemberDTO>?> GetEventMembers(int eventId)
        {
            var _event = unitOfWork.Events.GetByIdAsync(eventId);
            if (!_event.IsCompleted) return null;
            return await unitOfWork.EventMembers.GetEventMembers(eventId);
        }

        public async Task<bool> AddEventMember(EventMember eventMember)
        {
            
            if (eventMember.EventId == null)
                return false;
            var _event = await unitOfWork.Events.GetByIdAsync(eventMember.EventId.Value);
            if(_event == null) return false;
             await unitOfWork.EventMembers.AddEventMember(eventMember);
            return true;
        }
    }
}
