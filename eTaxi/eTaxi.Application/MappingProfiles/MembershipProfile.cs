using AutoMapper;
using eTaxi.Application.DTOs.Membership;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.Membership.Commands;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{

    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<MembershipDto, Membership>().ReverseMap();
            CreateMap<CreateMembershipCommand, Membership>().ReverseMap();
            CreateMap<UpdateMembershipCommand, Membership>().ReverseMap();
        }

    }
}
