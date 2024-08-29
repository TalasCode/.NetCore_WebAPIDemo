using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Core.Repositories
{
    public class MemberRepos(DbContext context) : Repository<Member>(context), IMemberRepos
    {
        private DatabaseServerContext DatabaseContext => (DatabaseServerContext)Context;
        public async Task<List<MemberDTO>> GetAllMembers()
        {
            return await DatabaseContext.Members
                .Select(m => new MemberDTO
                {
                     Id = m.Id,
                     Name = m.Name,
                     Email = m.Email,
                     DateOfBirth = m.DateOfBirth,
                     Gender = m.Gender,
                     JoiningDate = m.JoiningDate,
                     Profession = m.Profession,
                     Nationality = m.Nationality}).ToListAsync();
        }

        public async Task<MemberDTO?> GetMemberByEmail(string email)
        {
            return await DatabaseContext.Members
                .Where(m => m.Email == email).Select(m => new MemberDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    DateOfBirth = m.DateOfBirth,
                    Gender = m.Gender,
                    JoiningDate = m.JoiningDate,
                    Profession = m.Profession,
                    Nationality = m.Nationality
                }).FirstOrDefaultAsync();
        
        }
    }
}
