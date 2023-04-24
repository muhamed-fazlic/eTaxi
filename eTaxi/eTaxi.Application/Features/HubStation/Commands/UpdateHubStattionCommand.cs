using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.HubStation.Commands
{
    public  class UpdateHubStationCommand :IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
    }

    public class UpdateHubStationCommandHandler : IRequestHandler<UpdateHubStationCommand, Unit>
    {
        private readonly IHubStationRepository _hubStationRepository;
        private readonly IMapper _mapper;
        public UpdateHubStationCommandHandler(IHubStationRepository hubStationRepository, IMapper mapper)
        {
            _hubStationRepository = hubStationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateHubStationCommand request, CancellationToken cancellationToken)
        {
            var hubStation = await _hubStationRepository.GetByIdAsync(request.Id);
            if (hubStation == null)
            {
                throw new NotFoundException(nameof(HubStation), request.Id);
            }
            _mapper.Map(request, hubStation);
            await _hubStationRepository.UpdateAsync(hubStation);
            return Unit.Value;
        }
    }
}
