using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Location;
using MediatR;

namespace eTaxi.Application.Features.Location.Queries
{
    public record GetLocationQuery(int Id) : IRequest<LocationDto>
    {
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, LocationDto>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetLocationQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<LocationDto> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetByIdAsync(request.Id);
            var locationDto = _mapper.Map<LocationDto>(location);
            return locationDto;
        }
    }

}
