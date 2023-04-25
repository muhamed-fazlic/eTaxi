using AutoMapper;
using eTaxi.Application.DTOs.VehicleType;
using eTaxi.Application.Features.VehicleType.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class VehicleTypeProfile : Profile
    {
        public VehicleTypeProfile()
        {
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<CreateVehicleTypeCommand, VehicleType>().ReverseMap();
            CreateMap<UpdateVehicleTypeCommand, VehicleType>().ReverseMap();

        }
    }
}
