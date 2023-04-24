using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.HubStation.Commands
{
    public  class CreateHubStationCommand: IRequest<int>
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
    }

    public class CreateHubStationCommandHandler : IRequestHandler<CreateHubStationCommand, int>
    {
        private readonly IHubStationRepository _hubStationRepository;
        private readonly IMapper _mapper;
        public CreateHubStationCommandHandler(IHubStationRepository hubStationRepository, IMapper mapper)
        {
            _hubStationRepository = hubStationRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateHubStationCommand request, CancellationToken cancellationToken)
        {
            var hubStation = _mapper.Map<Domain.HubStation>(request);
            await _hubStationRepository.CreateAsync(hubStation);
            return hubStation.Id;
        }
    }

}
