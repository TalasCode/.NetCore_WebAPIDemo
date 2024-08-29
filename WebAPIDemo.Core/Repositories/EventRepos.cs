using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Repositories;
using WebAPIDemo.Core.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace WebAPIDemo.Core.Repositories
{
    public class EventRepos(DbContext context): Repository<Event> (context), IEventRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)Context;

        public async Task<List<EventDTO>?> GetAllEvents()
        {
            return await databaseContext.Events
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    name = e.Name,
                    CategoryId = e.CategoryId,
                    Destination = e.Destination,
                    Cost = e.Cost,
                    Status = e.Status,
                    UserId = e.UserId,

                }).ToListAsync();
                    
        }

        public async Task<List<EventDTO>?> GetEventByCategory(int CategoryId)
        {
            return await databaseContext.Events
                .Where(e => e.CategoryId == CategoryId)
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    name = e.Name,
                    CategoryId = e.CategoryId,
                    Destination = e.Destination,
                    Cost = e.Cost,
                    Status = e.Status,
                    UserId = e.UserId,

                }).ToListAsync();
        }

        public async Task<List<EventDTO>> GetEventByUser(int UserId)
        {
            return await databaseContext.Events
                .Where(e => e.UserId == UserId)
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    name = e.Name,
                    CategoryId = e.CategoryId,
                    Destination = e.Destination,
                    Cost = e.Cost,
                    Status = e.Status,
                    UserId = e.UserId,

                }).ToListAsync();

        }


        public async Task<bool> DeleteEvent(int eventId)
        {
            await databaseContext.Events.Where(e => e.Id == eventId).ExecuteDeleteAsync();
            return true;
        }




    }
}
