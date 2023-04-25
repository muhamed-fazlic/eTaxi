using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Vehicle.Commands
{
    public record DeleteVehicleCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Unit>
    {
        private readonly IVehicleRepository _context;
        public DeleteVehicleCommandHandler(IVehicleRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Vehicle), request.Id);
            }
            await _context.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
