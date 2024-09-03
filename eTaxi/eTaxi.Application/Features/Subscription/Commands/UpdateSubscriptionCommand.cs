using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Subscription.Commands
{
   
    public class UpdateSubscriptionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, Unit>
    {
        private readonly ISubscriptionRepository _context;
        private readonly IMapper _mapper;
        public UpdateSubscriptionCommandHandler(ISubscriptionRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.GetByIdAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Subscription), request.Id);
            }
            _mapper.Map(request, entity);

            entity.IsActive= entity.CalculateIsActive();
            await _context.UpdateAsync(entity);
            return Unit.Value;
        }
    }
}
