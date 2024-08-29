using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.DTO;

namespace WebAPIDemo.Core.Repositories
{
    public class EventGuidesRepos(DbContext context): Repository<EventGuide>(context) , IEventGuidesRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)Context;
        public async Task<List<GuideDTO>?> GetEventGuides(int eventId)
        {
            var eventGuideIds = await databaseContext.EventGuides
                .Where(eg => eg.EventId == eventId)
                .Select(eg => eg.GuidId)
                .ToListAsync();

            var guides = await databaseContext.Guides
                .Where(g => eventGuideIds.Contains(g.Id))
                .Select(g => new GuideDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Email = g.Email,
                    PasswordHash = g.PasswordHash,
                    DateOfBirth = g.DateOfBirth,
                    Gender = g.Gender,
                    JoiningDate = g.JoiningDate
                })
                .ToListAsync();

            return guides;
        }
        public async Task<bool> AddEventGuide(EventGuide eventGuide)
        {
            var eventExist = await databaseContext.Events.Where(e => e.Id == eventGuide.GuidId).FirstOrDefaultAsync();
            var guideExist = await databaseContext.Guides.Where(g => g.Id == eventGuide.GuidId).FirstOrDefaultAsync();
            if (eventExist == null || guideExist == null) return false;

            await databaseContext.EventGuides.AddAsync(eventGuide);
            await databaseContext.SaveChangesAsync();
            return true;

        }

    }
}
