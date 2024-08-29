using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Services.Services.IServices
{
    public interface IEventGuidesService
    {
        Task<List<GuideDTO>?> GetEventGuides(int eventId);

        Task<bool> AddEventGuide(EventGuide eventGuide);
        Task<bool> RemoveEventGuide(EventGuide eventGuide);
    }
}
