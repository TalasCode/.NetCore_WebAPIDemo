using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IEventService
    {
        Task<List<EventDTO>?> GetAllEvents();

        Task<List<EventDTO>?> GetEventByCategory(int CategoryId);

        Task<List<EventDTO>?> GetEventByUser(int UserId);

        Task<Event?> createEvent(Event _event);
        Task<Event?> updateEvent(int eventId, Event _event);
        Task<bool> DeleteEvent(int eventId);
    }
}
