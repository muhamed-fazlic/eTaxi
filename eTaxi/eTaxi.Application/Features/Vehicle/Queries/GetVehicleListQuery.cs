using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Vehicle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Vehicle.Queries
{
    public class GetVehicleListQuery: IRequest<List<VehicleDto>>
    {

    }

    public class GetVehicleListQueryHandler : IRequestHandler<GetVehicleListQuery, List<VehicleDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public GetVehicleListQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<List<VehicleDto>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            var vehicleList = await _vehicleRepository.GetAsync();
            return _mapper.Map<List<VehicleDto>>(vehicleList);
        }
    }
}
