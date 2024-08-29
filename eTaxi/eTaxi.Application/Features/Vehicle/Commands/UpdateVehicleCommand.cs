using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Vehicle.Commands
{
    public class UpdateVehicleCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double KmTraveled { get; set; }
        public string LicenceNumber { get; set; }
        public int Year { get; set; }
        public bool AirCondition { get; set; }
        public bool AirBag { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int? CurrentLocationId { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public double PricePerKm { get; set; }
        public int? UserDriverId { get; set; }
        public int TypeId { get; set; }
        public string ImageUrl { get; set; }
        public int? CompanyId { get; set; }

    }

    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Unit>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleToUpdate = await _vehicleRepository.GetByIdAsync(request.Id);
            if (vehicleToUpdate == null)
            {
                throw new NotFoundException(nameof(Domain.Vehicle), request.Id);
            }
            _mapper.Map(request, vehicleToUpdate);

            await _vehicleRepository.UpdateAsync(vehicleToUpdate);
            return Unit.Value;
        }
    }
}
