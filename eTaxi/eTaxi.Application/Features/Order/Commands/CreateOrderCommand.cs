using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Order.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
        public bool IsSelfDrive { get; set; }
        public DateTime? StartTime { get; set; }
        public double Price { get; set; }

    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToCreate = _mapper.Map<Domain.Order>(request);
            await _orderRepository.CreateAsync(orderToCreate);
            return orderToCreate.Id;
        }
    }

}
