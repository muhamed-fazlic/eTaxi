using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Location.Commands
{
    public  class UpdateLocationCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string StreetNumber { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Address { get; set; }
    }

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public UpdateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToUpdate = await _locationRepository.GetByIdAsync(request.Id);
            if (locationToUpdate == null)
            {
                throw new NotFoundException(nameof(Location), request.Id);
            }
            _mapper.Map(request, locationToUpdate);
            await _locationRepository.UpdateAsync(locationToUpdate);
            return Unit.Value;
        }
    }
}
