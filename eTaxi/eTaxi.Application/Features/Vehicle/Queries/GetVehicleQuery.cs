using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Vehicle;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Vehicle.Queries
{
    public record GetVehicleQuery(int Id) : IRequest<VehicleDto>
    {
    }

    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public GetVehicleQueryHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }
        public async Task<VehicleDto> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Vehicle), request.Id);
            return _mapper.Map<VehicleDto>(vehicle);
        }
    }
}
