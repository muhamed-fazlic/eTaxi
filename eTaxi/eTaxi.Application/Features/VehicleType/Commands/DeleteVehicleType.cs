using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class DeleteVehicleTypeCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteVehicleTypeCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteVehicleTypeCommandHandler: IRequestHandler<DeleteVehicleTypeCommand, bool>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public DeleteVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = await _vehicleTypeRepository.GetByIdAsync(request.Id);
            await _vehicleTypeRepository.DeleteAsync(vehicleType);
            return true;
        }
    }
}
