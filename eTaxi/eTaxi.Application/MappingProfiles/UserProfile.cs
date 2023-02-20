using AutoMapper;
using eTaxi.Application.DTOs.User;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
