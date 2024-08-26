using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IEventRepos : IRepository<Event>
    {
        Task<List<EventDTO>?> GetAllEvents();

        Task<List<EventDTO>?> GetEventByCategory(int CategoryId);

        Task<List<EventDTO>> GetEventByUser(int UserId);
        Task<bool> DeleteEvent(int eventId);

       

    }
}
