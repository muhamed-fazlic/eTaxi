using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using MediatR;

namespace eTaxi.Application.Features.Order.Queries
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {
        public OrderSearchDto Search { get; set; }
    }

    public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILocationRepository locationRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
        }

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetAsync(request.Search);

            foreach (var order in orderList)
            {
                var startLocation = await _locationRepository.GetByIdAsync(order.StartLocationId);
                order.StartLocation = startLocation;

                var endLocation = await _locationRepository.GetByIdAsync(order.EndLocationId);
                order.EndLocation = endLocation;

                var vehicle = await _vehicleRepository.GetByIdAsync(order.VehicleId);
                order.Vehicle = vehicle;

                if (order.UserId != null)
                {

                    var user = await _userRepository.GetByIdAsync((int)order.UserId);
                    order.User = user;
                }
            }
            return _mapper.Map<List<OrderDto>>(orderList);
        }
    }
}
