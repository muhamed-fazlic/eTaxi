using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Membership.Commands
{
   
    public record DeleteMembershipCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteMembershipCommandHandler : IRequestHandler<DeleteMembershipCommand, Unit>
    {
        private readonly IMembershipRepository _context;
        public DeleteMembershipCommandHandler(IMembershipRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
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
