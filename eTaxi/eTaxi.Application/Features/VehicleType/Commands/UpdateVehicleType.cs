using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.VehicleType;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class UpdateVehicleTypeCommand : IRequest<VehicleTypeDto>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public string ImageUrl { get; set; }
    }

    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, VehicleTypeDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        public UpdateVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }
        public async Task<VehicleTypeDto> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.Id);
            if (vehicleType == null)
            {
                throw new NotFoundException(nameof(VehicleType), request.Id);
            }
            vehicleType.Type = request.Type;
            vehicleType.NumberOfSeats = request.NumberOfSeats;
            vehicleType.ImageUrl = request.ImageUrl;
            await _vehicleTypeRepository.UpdateAsync(vehicleType);
            return _mapper.Map<VehicleTypeDto>(vehicleType);
        }
    }
}
