using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Rating;
using eTaxi.Application.DTOs.Subscription;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Subscription.Queries
{
  
    public class GetSubscriptionListQuery : IRequest<List<SubscriptionDto>>
    {
        public SubscriptionSearchDto Search { get; set; }
    }

    public class GetSubscriptionListQueryHandler : IRequestHandler<GetSubscriptionListQuery, List<SubscriptionDto>>
    {
        private readonly ISubscriptionRepository _context;
        private readonly IMapper _mapper;

        public GetSubscriptionListQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _context = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<List<SubscriptionDto>> Handle(GetSubscriptionListQuery request, CancellationToken cancellationToken)
        {
            var subsList = await _context.GetAsync(request.Search);
            return _mapper.Map<List<SubscriptionDto>>(subsList);
        }
    }
}
