using WebAPIDemo.Core.Models;
using WebAPIDemo.Core.Repositories.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core.Repositories
{
    public class UnitOfWork( DatabaseServerContext context , IConfiguration configuration) : IUnitOfWork
    {
        private UserRepos? _userRepository;
        private IRoleRepos? _roleRepository;
        private IEventRepos? _eventRepository;
        private IEventGuidesRepos? _eventGuideRepository;
        private IEventMembersRepos? _eventMemberRepository;
        private IMemberRepos? _memberRepository;
        private IGuideRepos? _guideRepository;
        private IAuthRepos? _authRepository;
        public IUserRepos Users =>
            _userRepository ??= new UserRepos(context);

        public IRoleRepos Roles =>
            _roleRepository ??= new RoleRepos(context);

        public IEventRepos Events =>
        _eventRepository ??= new EventRepos(context);

        public IEventGuidesRepos EventGuides =>
        _eventGuideRepository ??= new EventGuidesRepos(context);


        public IEventMembersRepos EventMembers =>
        _eventMemberRepository ??= new EventMembersRepos(context);
        public IMemberRepos Members =>
      _memberRepository ??= new MemberRepos(context);
        public IGuideRepos Guides =>
     _guideRepository ??= new GuideRepos(context);

        public IAuthRepos Auth =>
            _authRepository ??= new AuthRepos(context,configuration);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
