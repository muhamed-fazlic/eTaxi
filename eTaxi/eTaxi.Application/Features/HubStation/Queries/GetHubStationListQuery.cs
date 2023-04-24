using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.HubStation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.HubStation.Queries
{
    public class GetHubStationListQuery: IRequest<List<HubStationDto>>
    {
    }

    public class GetHubStationListQueryHandler : IRequestHandler<GetHubStationListQuery, List<HubStationDto>>
    {
        private readonly IHubStationRepository _hubStationRepository;
        private readonly IMapper _mapper;
        public GetHubStationListQueryHandler(IHubStationRepository hubStationRepository, IMapper mapper)
        {
            _hubStationRepository = hubStationRepository;
            _mapper = mapper;
        }
        public async Task<List<HubStationDto>> Handle(GetHubStationListQuery request, CancellationToken cancellationToken)
        {
            var allHubStations = await _hubStationRepository.GetAsync();
            return _mapper.Map<List<HubStationDto>>(allHubStations);
        }
    }
}
