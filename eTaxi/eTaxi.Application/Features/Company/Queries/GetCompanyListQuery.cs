using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Company;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Company.Queries
{
    public record GetCompanyListQuery() : IRequest<List<CompanyDto>>
    {
    }

    public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, List<CompanyDto>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetCompanyListQueryHandler(ICompanyRepository companyRepository, IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        public async Task<List<CompanyDto>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync();

            foreach (var item in company)
            {
                var vehicleList = await _vehicleRepository.GetAsync(new DTOs.Vehicle.VehicleSearchDto() { CompanyId = item.Id });
                item.Vehicles = (ICollection<Domain.Vehicle>)vehicleList;
            }
            return _mapper.Map<List<CompanyDto>>(company);
        }
    }
}
