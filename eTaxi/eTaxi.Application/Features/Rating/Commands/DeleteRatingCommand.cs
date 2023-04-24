using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Rating.Commands
{
    public record DeleteRatingCommand(int Id): IRequest<Unit>
    {
    }

    public class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, Unit>
    {
        private readonly IRatingRepository _context;
        public DeleteRatingCommandHandler(IRatingRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }
            await _context.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
