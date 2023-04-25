using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.Order.Commands
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int UserDriverId { get; set; }
        public int? UserId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int VehicleId { get; set; }
        public bool IsSelfDrive { get; set; }
        public DateTime? StartTime { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(request.Id);
            if (orderToUpdate == null) throw new NotFoundException(nameof(Domain.Order), request.Id);

            _mapper.Map(request, orderToUpdate);
            await _orderRepository.UpdateAsync(orderToUpdate);
            return Unit.Value;
        }
    }
}
