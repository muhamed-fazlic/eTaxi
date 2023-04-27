using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Vehicle.Commands
{
    public class CreateVehicleCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool AirCondition { get; set; }
        public bool AirBag { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int CurrentLocationId { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int PricePerKm { get; set; }
        public int? UserDriverId { get; set; }
        public int TypeId { get; set; }
        public string ImageUrl { get; set; }

    }

    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<Domain.Vehicle>(request);
            await _vehicleRepository.CreateAsync(vehicle);
            return vehicle.Id;
        }
    }
}
