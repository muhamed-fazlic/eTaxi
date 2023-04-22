using AutoMapper;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.DTOs.VehicleType;
using eTaxi.Application.Features.User.Commands.CreateUser;
using eTaxi.Application.Features.VehicleType.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class VehicleTypeProfile: Profile
    {
        public VehicleTypeProfile()
        {
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<CreateVehicleTypeCommand, VehicleType>().ReverseMap();
            CreateMap<UpdateVehicleTypeCommand, VehicleType>().ReverseMap();

        }
    }
}
