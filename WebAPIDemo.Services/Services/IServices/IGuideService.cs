using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IGuideService
    {
        Task<List<GuideDTO>> GetAllGuides();
        Task<Guide?> GetGuideById(int id);
        Task<GuideDTO> GetGuideByEmail(string email);
        Task<bool> Remove(Guide guide);
        Task<Guide> Add(Guide guide);
        Task<Guide> Update(Guide guide);
        Task<bool> DeleteGuide(int guideId);
    }
}
