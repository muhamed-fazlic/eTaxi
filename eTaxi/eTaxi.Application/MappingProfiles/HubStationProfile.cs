using AutoMapper;
using eTaxi.Application.DTOs.HubStation;
using eTaxi.Application.Features.HubStation.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class HubStationProfile : Profile
    {
        public HubStationProfile()
        {
            CreateMap<HubStationDto, HubStation>().ReverseMap();
            CreateMap<CreateHubStationCommand, HubStation>().ReverseMap();
            CreateMap<UpdateHubStationCommand, HubStation>().ReverseMap();
        }
    }
}
