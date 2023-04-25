using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using MediatR;

namespace eTaxi.Application.Features.Order.Queries
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
    }

    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetAsync();
            return _mapper.Map<List<OrderDto>>(orderList);
        }
    }
}
