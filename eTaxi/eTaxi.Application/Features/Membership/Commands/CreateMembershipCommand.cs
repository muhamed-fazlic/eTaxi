using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Membership.Commands
{
   
    public class CreateMembershipCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Tier { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, int>
    {
        private readonly IMembershipRepository _context;
        private readonly IMapper _mapper;
        public CreateMembershipCommandHandler(IMembershipRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Membership>(request);
            entity.IsActive=entity.CalculateIsActive();
            await _context.CreateAsync(entity);
            return entity.Id;
        }
    }
}
