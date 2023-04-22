using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.DTOs.VehicleType;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Features.User.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.VehicleType.Commands
{
    public class GetVehicleTypeQueryHandler : IRequestHandler<GetVehicleTypeQuery, VehicleTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public GetVehicleTypeQueryHandler(IMapper mapper,
            IVehicleTypeRepository vehicleTypeRepository
          )
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<VehicleTypeDto> Handle(GetVehicleTypeQuery request, CancellationToken cancellationToken)
        {
        
            var vehicleType=await _vehicleTypeRepository.GetByIdAsync(request.Id) ?? throw new
                NotFoundException(nameof(VehicleType), request.Id);
            return _mapper.Map<VehicleTypeDto>(vehicleType);

        }
    }

    public class GetVehicleTypeListHandler : IRequestHandler<GetVehicleTypeList, List<VehicleTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        public GetVehicleTypeListHandler(IMapper mapper,
                       IVehicleTypeRepository vehicleTypeRepository
                     )
        {
            _mapper = mapper;
            _vehicleTypeRepository = vehicleTypeRepository;
        }
        public async Task<List<VehicleTypeDto>> Handle(GetVehicleTypeList request, CancellationToken cancellationToken)
        {
            var vehicleTypeList = await _vehicleTypeRepository.GetAsync();
            return _mapper.Map<List<VehicleTypeDto>>(vehicleTypeList);
        }
    }

}
