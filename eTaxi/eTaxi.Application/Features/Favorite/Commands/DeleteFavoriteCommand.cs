using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Favorite.Commands
{
    public record DeleteFavoriteCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, Unit>
    {
        private readonly IFavoriteRepository _context;
        public DeleteFavoriteCommandHandler(IFavoriteRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Favorite), request.Id);
            }
            await _context.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
