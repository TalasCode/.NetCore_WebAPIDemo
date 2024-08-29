using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services.IServices;
using WebAPIDemo.Core.Models;
namespace WebAPIDemo.Services.Services
{
    public class MemberService(IUnitOfWork unitOfWork) : IMemberService
    {
        public async Task<List<MemberDTO>> GetAllMembers()
        {
            try{
                return await unitOfWork.Members.GetAllMembers();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        public async Task<Member?> GetMemberById(int id)
        {
            try
            {
                var member = await unitOfWork.Members.GetByIdAsync(id);
                return member;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<MemberDTO?> GetMemberByEmail(string email)
        {
            try
            {
                return await unitOfWork.Members.GetMemberByEmail(email);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public async Task<bool> Remove(Member member)
            {
            try
            {
                if (await unitOfWork.Members.GetByIdAsync(member.Id) == null) return false;
                else
                {
                    unitOfWork.Members.Remove(member);
                    await unitOfWork.CommitAsync();
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
            }

        public async Task<Member> Add(Member member)
        {
             await unitOfWork.Members.AddAsync(member);
           await unitOfWork.CommitAsync();
            return member;
        }
    }
}
