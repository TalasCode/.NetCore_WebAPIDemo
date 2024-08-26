﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IEventGuidesRepos : IRepository<EventGuide>
    {
        Task<List<GuideDTO>?> GetEventGuides(int eventId);


        Task<bool> AddEventGuide(EventGuide eventGuide);
    }
}
