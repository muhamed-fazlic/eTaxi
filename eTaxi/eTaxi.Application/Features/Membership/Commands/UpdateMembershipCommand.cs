using AutoMapper;
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
  
    public class UpdateMembershipCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Tier { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand, Unit>
    {
        private readonly IMembershipRepository _context;
        private readonly IMapper _mapper;
        public UpdateMembershipCommandHandler(IMembershipRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }
            _mapper.Map(request, entity);
            entity.IsActive=entity.CalculateIsActive();
            await _context.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
