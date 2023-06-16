using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Rating;
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
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper, ILocationRepository locationRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository, IRatingRepository ratingRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<List<OrderDto>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetAsync(request.Search);

            foreach (var order in orderList)
            {
                if (order.StartLocationId != null)
                {
                    var startLocation = await _locationRepository.GetByIdAsync((int)order.StartLocationId);
                    order.StartLocation = startLocation;
                }

                if (order.EndLocationId != null)
                {
                    var endLocation = await _locationRepository.GetByIdAsync((int)order.EndLocationId);
                    order.EndLocation = endLocation;
                }

                var vehicle = await _vehicleRepository.GetByIdAsync(order.VehicleId);
                order.Vehicle = vehicle;

                if (order.UserId != null)
                {
                    var user = await _userRepository.GetByIdAsync((int)order.UserId);
                    order.User = user;
                }
            }

            var orderDtoList = _mapper.Map<List<OrderDto>>(orderList);

            foreach (var order in orderDtoList)
            {
                var rating = await _ratingRepository.GetAsync(new DTOs.Rating.RatingSearchDto { OrderId = order.Id });

                if (rating != null)
                {
                    order.Rating= _mapper.Map<RatingDto>(rating.FirstOrDefault());
                }
            }

            return orderDtoList;
        }
    }
}
