using AutoMapper;
using eTaxi.Application.DTOs.File;
using eTaxi.Application.Features.File.Commands;
using eTaxi.Application.Models.Photo;

namespace eTaxi.Application.MappingProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDto, Domain.File>().ReverseMap();
            CreateMap<PhotoResponse, Domain.File>().ReverseMap();
            CreateMap<CreateFileCommand, Domain.File>().ReverseMap();
            CreateMap<UpdateFileCommand, Domain.File>().ReverseMap();
        }
    }
}
