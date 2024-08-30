using AutoMapper;
using eTaxi.Application.DTOs.FITPasos;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.Features.FITPasos.Commands;
using eTaxi.Application.Features.Order.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class FITPasosProfile:Profile
    {
        public FITPasosProfile()
        {
            CreateMap<FITPasosDto, FITPasos>().ReverseMap();
            CreateMap<CreateFITPasosCommand, FITPasos>().ReverseMap();
            CreateMap<UpdateFITPasosCommand, FITPasos>().ReverseMap();
        }
    }
}
