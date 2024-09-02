using AutoMapper;
using eTaxi.Application.DTOs.MaliciousUser;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.MaliciousUser.Commands;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    internal class MaliciousUserProfile: Profile
    {
        public MaliciousUserProfile()
        {
            CreateMap<MaliciousUserDto, MaliciousUser>().ReverseMap();
            CreateMap<CreateMaliciousUserCommand, MaliciousUser>().ReverseMap();
            CreateMap<UpdateMaliciousUserCommand, MaliciousUser>().ReverseMap();
        }
    }

   
}
