using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Contracts.Reports;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.DTOs.Reports;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Exceptions;
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

            if(orders == null || !orders.Any())
            {
                return new ReportDto();
            }

            foreach (var order in orders)
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

            //
            var userWithMostOrders = orders
                .GroupBy(order => order.UserId)
                .OrderByDescending(group => group.Count())
                .Select(group => (int?)group.Key)  // Cast Key as nullable int
                .FirstOrDefault();

            var userDriverWithMostOrders = orders
                .GroupBy(order => order.UserDriverId)
                .OrderByDescending(group => group.Count())
                .Select(group => (int?)group.Key)  // Cast Key as nullable int
                .FirstOrDefault();

            //Create list of orders by user and order by most orders
            List<UserOrderCount> userOrderCounts = orders.GroupBy(order => order.UserId)
                                                 .Select(group => new UserOrderCount
                                                 {
                                                     UserName = group.First().User?.FirstName+ " "+ group.First().User?.LastName,
                                                     UserId = group.Key,
                                                     OrderCount = group.Count()
                                                 }).OrderByDescending(group => group.OrderCount)
                                                 .ToList();

            //Create list of orders by vehicles and order by most orders
            List<VehicleOrderCount> vehicleOrderCounts = orders.GroupBy(order => order.VehicleId)
                                           .Select(group => new VehicleOrderCount
                                           {
                                               VehicleName = group.First().Vehicle.Name,
                                               VehicleId = group.Key,
                                               OrderCount = group.Count()
                                           }).OrderByDescending(group => group.OrderCount)
                                           .ToList();

            // Group orders by start time and count the occurrences

            //var frequentHourRanges = orders.GroupBy(order =>
            //{
            //    TimeSpan hourRange = TimeSpan.FromHours(1);
            //    TimeSpan roundedStart = TimeSpan.FromTicks((long)(order.StartTime?.Ticks + (hourRange.Ticks / 2)) / hourRange.Ticks * hourRange.Ticks);
            //    return roundedStart;
            //})
            //.Select(group => new { HourRange = group.Key.Hours, Count = group.Count() })
            //.OrderByDescending(group => group.Count);

            var frequentHourRanges = orders
            .SelectMany(order =>
            {
                List<string> hourRanges = new List<string>();

                DateTime currentHour = (DateTime)order.StartTime;
                DateTime? endHour = order.EndTime ?? order.StartTime;

                while (currentHour <= endHour)
                {
                    string hourRange = $"{currentHour.ToString("h tt")} - {currentHour.AddHours(1).ToString("h tt")}";
                    hourRanges.Add(hourRange);
                    currentHour = currentHour.AddHours(1);
                }

                return hourRanges;
            })
            .GroupBy(hourRange => hourRange)
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
                UserWithMostOrders = userWithMostOrders.HasValue ? _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userWithMostOrders.Value)) : null,
                DriverWithMostOrders = userDriverWithMostOrders.HasValue ? _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(userDriverWithMostOrders.Value)) : null,
                UserOrderCount = userOrderCounts,
                VehicleOrderCount = vehicleOrderCounts,
                MostFrequentTime = frequentHourRanges,
                MostFrequentRoute = frequentRoutes

            };


            return response;


        }
    }

}

