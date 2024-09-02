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
                throw;
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
        public async Task<bool> DeleteMember(int memberId)
            {
            try
            {
                if (await unitOfWork.Members.GetByIdAsync(memberId) == null) return false;
                else
                {
                    await unitOfWork.Members.DeleteMember(memberId);
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
        public async Task<Member> Update(Member member)
        {
            try
            {
                Member? existingMember = await unitOfWork.Members.GetByIdAsync(member.Id);
                if (existingMember == null) throw new NotFoundException("Member Not Found");
                existingMember.Name = member.Name;
                existingMember.Email = member.Email;
                existingMember.Gender = member.Gender;
                existingMember.JoiningDate = member.JoiningDate;
                existingMember.EmergencyNumber = member.EmergencyNumber;
                existingMember.Photo = member.Photo;
                existingMember.DateOfBirth = member.DateOfBirth;
                existingMember.Profession = member.Profession;
              await unitOfWork.Members.UpdateAsync(existingMember);
                await unitOfWork.CommitAsync();
                return existingMember;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
