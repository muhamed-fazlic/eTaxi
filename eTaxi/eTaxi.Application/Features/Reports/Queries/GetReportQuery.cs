using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Contracts.Reports;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Reports;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Models.Identity;
using eTaxi.Domain;
using MediatR;


namespace eTaxi.Application.Features.Reports.Queries
{
    public class GetReportQuery : IRequest<ReportDto>
    {
        public ReportSearchDTO Search { get; set; }
    }

    public class GetReportQueryHandler : IRequestHandler<GetReportQuery, ReportDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;
        public GetReportQueryHandler(IOrderRepository orderRepository, IVehicleRepository vehicleRepository, IUserRepository userRepository, IMapper mapper, ILocationRepository locationRepository)
        {

            _orderRepository = orderRepository;
            _vehicleRepository = vehicleRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
        }
        public async Task<ReportDto> Handle(GetReportQuery request, CancellationToken cancellationToken)

        {
            var orders = await _orderRepository.GetAsync(new DTOs.Order.OrderSearchDto
            {
                CompanyId = request.Search.CompanyId,
                StartTime = request.Search.StartDate,
                EndTime = request.Search.EndDate,
            });

            foreach (var order in orders)
            {
                var startLocation = await _locationRepository.GetByIdAsync(order.StartLocationId);
                order.StartLocation = startLocation;

                var endLocation = await _locationRepository.GetByIdAsync(order.EndLocationId);
                order.EndLocation = endLocation;

            }


            //
            var userWithMostOrders = orders.GroupBy(order => order.UserId)
                                       .OrderByDescending(group => group.Count())
                                       .FirstOrDefault().Key;

            var userDriverWithMostOrders = orders.GroupBy(order => order.UserDriverId)
                                   .OrderByDescending(group => group.Count())
                                   .FirstOrDefault().Key;

            //Create list of orders by user and order by most orders
            List<UserOrderCount> userOrderCounts = orders.GroupBy(order => order.UserId)
                                                 .Select(group => new UserOrderCount
                                                 {
                                                     UserId = group.Key,
                                                     OrderCount = group.Count()
                                                 }).OrderByDescending(group => group.OrderCount)
                                                 .ToList();

            //Create list of orders by vehicles and order by most orders
            List<VehicleOrderCount> vehicleOrderCounts = orders.GroupBy(order => order.VehicleId)
                                           .Select(group => new VehicleOrderCount
                                           {
                                               VehicleId = group.Key,
                                               OrderCount = group.Count()
                                           }).OrderByDescending(group => group.OrderCount)
                                           .ToList();

            // Group orders by start time and count the occurrences

            var frequentHourRanges = orders.GroupBy(order =>
            {
                TimeSpan hourRange = TimeSpan.FromHours(1);
                TimeSpan roundedStart = TimeSpan.FromTicks((long)(order.StartTime?.Ticks + (hourRange.Ticks / 2)) / hourRange.Ticks * hourRange.Ticks);
                return roundedStart;
            })
 .Select(group => new { HourRange = group.Key, Count = group.Count() })
 .OrderByDescending(group => group.Count);

            // Group orders by rounded route (start location to end location) and count the occurrences
            var frequentRoutes = orders.GroupBy(order =>
            {
                int decimalPlaces = 4; // Specify the number of decimal places for rounding

                double startLatitude = Math.Round((double)order.StartLocation.Latitude, decimalPlaces);
                double startLongitude = Math.Round((double)order.StartLocation.Longitude, decimalPlaces);
                double endLatitude = Math.Round((double)order.EndLocation.Latitude, decimalPlaces);
                double endLongitude = Math.Round((double)order.EndLocation.Longitude, decimalPlaces);

                return new { StartLocation = new { Latitude = startLatitude, Longitude = startLongitude }, EndLocation = new { Latitude = endLatitude, Longitude = endLongitude } };
            })
            .Select(group => new { Route = group.Key, Count = group.Count() })
            .OrderByDescending(group => group.Count);


            var response = new ReportDto
            {
                TotalOrders = orders.Count,
                TotalCanceledOrders = orders.Where(order => order.IsCanceled == true).Count(),
                TotalEarnedMoney = orders.Aggregate(0.0, (sum, order) => sum + order.Price),
                UserWithMostOrders = _mapper.Map<UserDto>(await _userRepository.GetByIdAsync((int)userWithMostOrders)),
                DriverWithMostOrders = _mapper.Map<UserDto>(await _userRepository.GetByIdAsync((int)userDriverWithMostOrders)),
                UserOrderCount = userOrderCounts,
                VehicleOrderCount = vehicleOrderCounts,
                MostFrequentTime = frequentHourRanges,
                MostFrequentRoute = frequentRoutes

            };


            return response;


        }
    }
}
