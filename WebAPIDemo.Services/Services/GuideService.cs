using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories;
using WebAPIDemo.Core.Repositories.IRepositories;
using WebAPIDemo.Services.Services.IServices;
namespace WebAPIDemo.Services.Services
{
    public class GuideService(IUnitOfWork unitOfWork) : IGuideService
    {
        public async Task<List<GuideDTO>> GetAllGuides()
        {
            try
            {
                return await unitOfWork.Guides.GetAllGuides();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<Guide?> GetGuideById(int id)
        {
            try
            {
                var guide = await unitOfWork.Guides.GetByIdAsync(id);
                return guide;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<GuideDTO?> GetGuideByEmail(string email)
        {
            try
            {
                return await unitOfWork.Guides.GetGuideByEmail(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Remove(Guide guide)
        {
            try
            {
                if (await unitOfWork.Guides.GetByIdAsync(guide.Id) == null) return false;
                else
                {
                    unitOfWork.Guides.Remove(guide);
                    await unitOfWork.CommitAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<Guide> Add(Guide guide)
        {
            await unitOfWork.Guides.AddAsync(guide);
            await unitOfWork.CommitAsync();
            return guide;
        }
        public async Task<Guide> Update(Guide guide)
        {
            try
            {
                Guide? existingGuide = await unitOfWork.Guides.GetByIdAsync(guide.Id);
                if (existingGuide == null) throw new NotFoundException("Guide Not Found");
                existingGuide.Name = guide.Name;
                existingGuide.Email = guide.Email;
                existingGuide.Gender = guide.Gender;
                existingGuide.JoiningDate = guide.JoiningDate;
                existingGuide.PasswordHash = guide.PasswordHash;
                existingGuide.Photo = guide.Photo;
                existingGuide.DateOfBirth = guide.DateOfBirth;
                existingGuide.Profession = guide.Profession;
                await unitOfWork.Guides.UpdateAsync(existingGuide);
                await unitOfWork.CommitAsync();
                return existingGuide;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> DeleteGuide(int guideId)
        {
            var ExistingGuide = unitOfWork.Guides.GetByIdAsync(guideId);
            if (ExistingGuide.IsCanceled) return false;
            await unitOfWork.Guides.DeleteGuide(guideId);
            return true;
        }
    }
}
