using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Subscription;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Subscription.Commands
{

    public class CreateSubscriptionCommand : IRequest<SubscriptionDto>
    {
        public int UserId { get; set; }
        public string SubscriptionType { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, SubscriptionDto>
    {
        private readonly ISubscriptionRepository _context;
        private readonly IMapper _mapper;
        public CreateSubscriptionCommandHandler(ISubscriptionRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SubscriptionDto> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {

            var entity = new Domain.Subscription(request.StartTime, request.EndTime);

            _mapper.Map(request, entity);

            await _context.CreateAsync(entity);
            var subDto = _mapper.Map<SubscriptionDto>(entity);
            return subDto;
        }
    }
}
