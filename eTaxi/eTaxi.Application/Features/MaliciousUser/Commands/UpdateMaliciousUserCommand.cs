using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.MaliciousUser.Commands
{
  

    public class UpdateMaliciousUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public bool IsSuspicious { get; set; }
    }

    public class UpdateMaliciousUserCommandHandler : IRequestHandler<UpdateMaliciousUserCommand, Unit>
    {
        private readonly IMaliciousUserRepository _context;
        private readonly IMapper _mapper;
        public UpdateMaliciousUserCommandHandler(IMaliciousUserRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMaliciousUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(MaliciousUser), request.Id);
            }
            _mapper.Map(request, entity);
            await _context.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
