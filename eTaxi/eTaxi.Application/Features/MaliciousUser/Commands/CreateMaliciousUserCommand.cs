using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.MaliciousUser.Commands
{
   
    public class CreateMaliciousUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public bool IsSuspicious { get; set; }
    }

    public class CreateMaliciousUserCommandHandler : IRequestHandler<CreateMaliciousUserCommand, int>
    {
        private readonly IMaliciousUserRepository _context;
        private readonly IMapper _mapper;
        public CreateMaliciousUserCommandHandler(IMaliciousUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateMaliciousUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.MaliciousUser>(request);
            await _context.CreateAsync(entity);
            return entity.Id;
        }
    }
}
