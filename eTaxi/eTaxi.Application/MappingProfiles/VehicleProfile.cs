using AutoMapper;
using eTaxi.Application.DTOs.Vehicle;
using eTaxi.Application.Features.Vehicle.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<UpdateVehicleCommand, Vehicle>().ReverseMap();
            CreateMap<CreateVehicleCommand, Vehicle>().ReverseMap();
        }
    }
}
