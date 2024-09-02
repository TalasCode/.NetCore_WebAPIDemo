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
    public class GuideRepos(DbContext context) : Repository<Guide>(context), IGuideRepos
    {
        private DatabaseServerContext DatabaseContext => (DatabaseServerContext)Context;

        public async Task<List<GuideDTO>> GetAllGuides()
        {
            return await DatabaseContext.Guides.Select(g => new GuideDTO
            {
                Id = g.Id,
                Name = g.Name,
                Email = g.Email,
                DateOfBirth = g.DateOfBirth,
                Gender = g.Gender,
                JoiningDate = g.JoiningDate,
                PasswordHash = g.PasswordHash,
            }).ToListAsync();
        }

        public async Task<GuideDTO?> GetGuideByEmail(string email)
        {
            return await DatabaseContext.Guides.Where(g => g.Email == email)
                .Select(g => new GuideDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Email = g.Email,
                    DateOfBirth = g.DateOfBirth,
                    Gender = g.Gender,
                    JoiningDate = g.JoiningDate,
                    PasswordHash = g.PasswordHash,
                }).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteGuide(int guideId)
        {
             await DatabaseContext.Guides.Where(g=> g.Id == guideId).ExecuteDeleteAsync();
            await DatabaseContext.SaveChangesAsync();
            return true;
        }
    }
}
