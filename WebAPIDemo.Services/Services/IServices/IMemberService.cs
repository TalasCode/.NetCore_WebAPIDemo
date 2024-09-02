using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IMemberService
    {
        Task<List<MemberDTO>> GetAllMembers();
        Task<Member?> GetMemberById(int id);
        Task<MemberDTO> GetMemberByEmail(string email);
        Task<bool> DeleteMember(int memberId);
        Task<Member> Add(Member member);
        Task<Member> Update(Member member);
    }
}
