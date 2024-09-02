using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Repositories.IRepositories;

namespace WebAPIDemo.Core.Repositories.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepos Users { get;}
        public IRoleRepos Roles { get; }
        public IEventRepos Events { get; }
        public IEventGuidesRepos EventGuides { get; }
        public IEventMembersRepos EventMembers { get; }

        public IMemberRepos Members { get; }
        public IGuideRepos Guides { get; }
        public IAuthRepos Auth { get; }

        Task<int> CommitAsync();
    }
}
