using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Location.Commands
{
    public record DeleteLocationCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
    {
        private readonly ILocationRepository _repository;
        public DeleteLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id);
            if (location == null)
            {
                throw new NotFoundException(nameof(Location), request.Id);
            }
            await _repository.DeleteAsync(location);
            return Unit.Value;
        }
    }
}
