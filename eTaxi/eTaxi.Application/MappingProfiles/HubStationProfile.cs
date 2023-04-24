using AutoMapper;
using eTaxi.Application.DTOs.HubStation;
using eTaxi.Application.Features.HubStation.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class HubStationProfile: Profile
    {
        public HubStationProfile()
        { 
            CreateMap<HubStationDto, HubStation>().ReverseMap();
            CreateMap<CreateHubStationCommand, HubStation>().ReverseMap();
            CreateMap<UpdateHubStationCommand, HubStation>().ReverseMap();
        }
    }
}
