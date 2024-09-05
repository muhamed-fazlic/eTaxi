using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using eTaxi.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.ToDo.Commands
{
   
    public record DeleteToDoCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, Unit>
    {
        private readonly IToDoRepository _context;
        public DeleteToDoCommandHandler(IToDoRepository context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ToDo4924), request.Id);
            }
            await _context.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
