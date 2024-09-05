using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.ToDo.Commands
{
    
    public class CreateToDoCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Naziv { get; set; } = string.Empty;
        public string Opis { get; set; } = string.Empty;
        public DateTime KrajnjiRok { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, int>
    {
        private readonly IToDoRepository _context;
        private readonly IMapper _mapper;
        public CreateToDoCommandHandler(IToDoRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.ToDo4924>(request);
            await _context.CreateAsync(entity);
            return entity.Id;
        }
    }
}
