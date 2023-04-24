using AutoMapper;
using eTaxi.Application.DTOs.Location;
using eTaxi.Application.Features.Location.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<UpdateLocationCommand, Location>().ReverseMap();
            CreateMap<CreateLocationCommand, Location>().ReverseMap();
        }
       
    }
}
