using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Location.Commands
{
    public class CreateLocationCommand : IRequest<int>
    {
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

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, int>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToCreate = _mapper.Map<Domain.Location>(request);
            await _locationRepository.CreateAsync(locationToCreate);
            return locationToCreate.Id;
        }
    }
}
