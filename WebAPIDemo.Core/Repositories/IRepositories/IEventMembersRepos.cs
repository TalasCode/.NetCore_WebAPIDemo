﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.DTO;
using WebAPIDemo.Core.Models;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IEventMembersRepos : IRepository<EventMember>
    {
        Task<List<MemberDTO>?> GetEventMembers(int eventId);
        Task<bool> AddEventMember(EventMember eventGuide);


    }
}
