using AutoMapper;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.ToDo;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.ToDo.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
   
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<TodoDto, ToDo4924>().ReverseMap();
            CreateMap<CreateToDoCommand, ToDo4924>().ReverseMap();
            CreateMap<UpdateToDoCommand, ToDo4924>().ReverseMap();
        }

    }
}
