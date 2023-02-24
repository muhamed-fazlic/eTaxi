using AutoMapper;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Features.User.Commands.CreateUser;
using eTaxi.Application.Features.User.Commands.UpdateUser;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UpdateUserCommand, User>().ReverseMap();
        }
    }
}
