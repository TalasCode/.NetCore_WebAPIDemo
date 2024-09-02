using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.DTO;
using Microsoft.Extensions.Logging;
namespace WebAPIDemo.Services.Services
{
    public class EventGuidesService(IUnitOfWork unitOfWork) : IEventGuidesService
    {
        public async Task<List<GuideDTO>?> GetEventGuides(int eventId)
        {
            
            return await unitOfWork.EventGuides.GetEventGuides(eventId);
        }

        public async Task<bool> AddEventGuide(EventGuide eventGuide)
        {

            if (eventGuide.EventId == null)
                return false;
            var _event = await unitOfWork.Events.GetByIdAsync(eventGuide.EventId.Value);
            if (_event == null) return false;
             await unitOfWork.EventGuides.AddEventGuide(eventGuide);
            
            return true;
        }

        public async Task<bool> RemoveEventGuide(EventGuide eventGuide)
        {
            try
            {
                var existingEventGuide = await unitOfWork.EventMembers.GetByIdAsync(eventGuide.Id);
                if (existingEventGuide != null)
                {
                    unitOfWork.EventMembers.Remove(existingEventGuide);
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
