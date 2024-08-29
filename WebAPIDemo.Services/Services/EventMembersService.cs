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
            try
            {
                
                return await unitOfWork.EventMembers.GetEventMembers(eventId);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        public async Task<bool> RemoveEventMember(EventMember eventMember)
        {
            try
            {
                var existingEventMember = await unitOfWork.EventMembers.GetByIdAsync(eventMember.Id);
                if (existingEventMember != null)
                {
                    unitOfWork.EventMembers.Remove(existingEventMember);
                    await unitOfWork.CommitAsync();
                    return true;
                }
                else
                {
                    return false; // EventMember not found
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("An error occurred while removing the event member.", ex);
            }
        }

    }
}
