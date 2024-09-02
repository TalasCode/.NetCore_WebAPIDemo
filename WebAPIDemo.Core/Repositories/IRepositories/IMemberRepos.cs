using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IMemberRepos : IRepository<Member>
    {
        Task<List<MemberDTO>> GetAllMembers();
        Task<MemberDTO?> GetMemberByEmail(string email);
        Task<bool> DeleteMember(int memberId);
    }
}
