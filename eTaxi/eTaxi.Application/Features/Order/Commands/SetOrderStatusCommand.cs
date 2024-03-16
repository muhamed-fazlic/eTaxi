using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.Exceptions;
using MediatR;


namespace eTaxi.Application.Features.Order.Commands
{
    public class SetOrderStatusCommand: IRequest<Unit>
    {
        public OrderStatusDto status { get; set; }
    }

    public class SetOrderStatusCommandHandler : IRequestHandler<SetOrderStatusCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        public SetOrderStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(SetOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.status.OrderId);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.status.OrderId);
            }
            if (request.status.IsActive != null)
            {
                order.IsActive = (bool)request.status.IsActive;

            }
            if(request.status.IsCanceled!= null)
            {
                order.IsCanceled = request.status.IsCanceled;
                order.CancelReason = request.status.CancelReason;
                order.IsActive = false;
            }
            
            await _orderRepository.UpdateAsync(order);
            return Unit.Value;
        }
    }
}
