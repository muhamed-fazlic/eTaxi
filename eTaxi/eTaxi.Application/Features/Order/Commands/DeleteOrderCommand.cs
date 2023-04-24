using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.Features.Order.Commands
{
    public record DeleteOrderCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            await _orderRepository.DeleteAsync(order);
            return Unit.Value;
        }
    }
}
