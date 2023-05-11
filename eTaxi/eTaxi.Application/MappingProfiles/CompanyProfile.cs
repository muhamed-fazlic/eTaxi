using AutoMapper;
using eTaxi.Application.DTOs.Company;
using eTaxi.Application.Features.Company.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<CreateCompanyCommand, Company>().ReverseMap();

        }
    }
}
