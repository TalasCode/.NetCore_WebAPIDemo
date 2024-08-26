using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;

namespace WebAPIDemo.Core.Repositories
{
    public class EventMembersRepos(DbContext context) :Repository<EventMember>(context) ,IEventMembersRepos
    {
        private DatabaseServerContext databaseContext => (DatabaseServerContext)context;

        public async Task<List<MemberDTO>?> GetEventMembers(int eventId)
        {
            var eventMembersIds = await databaseContext.EventMembers
                .Where(em => em.EventId == eventId)
                .Select(em => em.MemberId)
                .ToListAsync();

            var Members = await databaseContext.Members
                .Where(m => eventMembersIds.Contains(m.Id))
                .Select(m => new MemberDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    DateOfBirth = m.DateOfBirth,
                    Gender = m.Gender,
                    JoiningDate = m.JoiningDate,
                    Profession = m.Profession,
                    Nationality = m.Nationality,
                })
                .ToListAsync();

            return Members;
        }

        public async Task<bool> AddEventMember(EventMember eventMember)
        {
            var eventExist = await databaseContext.Events.Where(e => e.Id == eventMember.MemberId).FirstOrDefaultAsync();
            var MemberExist = await databaseContext.Guides.Where(m => m.Id == eventMember.MemberId).FirstOrDefaultAsync();
            if (eventExist == null || MemberExist == null) return false;

            await databaseContext.EventMembers.AddAsync(eventMember);
            await databaseContext.SaveChangesAsync();
            return true;
        }



    }
}
