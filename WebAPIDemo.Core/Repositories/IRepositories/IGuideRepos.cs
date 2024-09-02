using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IGuideRepos :IRepository<Guide>
    {
        Task<List<GuideDTO>> GetAllGuides();
        Task<GuideDTO?> GetGuideByEmail(string email);
        Task<bool> DeleteGuide(int guideId);
    }
}
