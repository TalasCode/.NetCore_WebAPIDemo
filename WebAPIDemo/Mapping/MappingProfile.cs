using WebAPIDemo.Core.Models;
using WebAPIDemo.Request;
using AutoMapper;
namespace WebAPIDemo.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<UserRequest, User>();
            CreateMap<EventRequest, Event>();
            
        }
    }
}
