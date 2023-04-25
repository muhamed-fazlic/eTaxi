using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.HubStation.Commands
{
    public record DeleteHubStationCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteHubStationCommandHandler : IRequestHandler<DeleteHubStationCommand, Unit>
    {
        private readonly IHubStationRepository _hubStationRepository;

        public DeleteHubStationCommandHandler(IHubStationRepository hubStationRepository)
        {
            _hubStationRepository = hubStationRepository;
        }

        public async Task<Unit> Handle(DeleteHubStationCommand request, CancellationToken cancellationToken)
        {
            var hubStation = await _hubStationRepository.GetByIdAsync(request.Id);
            await _hubStationRepository.DeleteAsync(hubStation);
            return Unit.Value;
        }
    }
}
