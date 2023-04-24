using AutoMapper;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class RatingProfile: Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<CreateRatingCommand, Rating>().ReverseMap();
            CreateMap<UpdateRatingCommand, Rating>().ReverseMap();
        }
        
    }
}
