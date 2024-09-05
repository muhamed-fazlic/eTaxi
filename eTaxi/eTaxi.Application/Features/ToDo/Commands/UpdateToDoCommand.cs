using AutoMapper;
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
 
    public class UpdateToDoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public DateTime? KrajnjiRok { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, Unit>
    {
        private readonly IToDoRepository _context;
        private readonly IMapper _mapper;
        public UpdateToDoCommandHandler(IToDoRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(ToDo4924), request.Id);
            }
            _mapper.Map(request, entity);
            await _context.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
