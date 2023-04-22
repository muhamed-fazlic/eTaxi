using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IAppLogger<CreateVehicleTypeCommandHandler> _logger;
        public CreateVehicleTypeCommandHandler(IMapper mapper,
                       IVehicleTypeRepository vehicleTypeRepository,
                                  IAppLogger<CreateVehicleTypeCommandHandler> logger)
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {

            var vehicleTypeToCreate = _mapper.Map<Domain.VehicleType>(request);
            await _vehicleTypeRepository.CreateAsync(vehicleTypeToCreate);
            return vehicleTypeToCreate.Id;
        }


    }
}
