using AutoMapper;
using eTaxi.Application.DTOs.Vehicle;
using eTaxi.Application.Features.Vehicle.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class VehicleProfile: Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<UpdateVehicleCommand, Vehicle>().ReverseMap();
            CreateMap<CreateVehicleCommand, Vehicle>().ReverseMap();
        }
    }
}
