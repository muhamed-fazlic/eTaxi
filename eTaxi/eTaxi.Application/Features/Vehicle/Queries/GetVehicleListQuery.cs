using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Vehicle;
using MediatR;

namespace eTaxi.Application.Features.Vehicle.Queries
{
    public class GetVehicleListQuery : IRequest<List<VehicleDto>>
    {
        public VehicleSearchDto Search { get; set; }
    }

    public class GetVehicleListQueryHandler : IRequestHandler<GetVehicleListQuery, List<VehicleDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly ICompanyRepository _companyRepository;

        private readonly IMapper _mapper;

        public GetVehicleListQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper, IVehicleTypeRepository vehicleTypeRepository, ICompanyRepository companyRepository)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _companyRepository = companyRepository;
        }

        public async Task<List<VehicleDto>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            var vehicleList = await _vehicleRepository.GetAsync(request.Search);
            foreach (var vehicle in vehicleList)
            {
                var vehicleType = await _vehicleTypeRepository.GetByIdAsync(vehicle.TypeId);
                vehicle.Type = vehicleType;
                if (vehicle.CompanyId != null)
                {
                    var company = await _companyRepository.GetByIdAsync((int)vehicle.CompanyId);
                    vehicle.Company = company;

                }

            }
            return _mapper.Map<List<VehicleDto>>(vehicleList);
        }
    }
}
