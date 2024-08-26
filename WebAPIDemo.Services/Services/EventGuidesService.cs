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
            var _event = unitOfWork.Events.GetByIdAsync(eventId);
            if(!_event.IsCompleted) return null;
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
    }
}
