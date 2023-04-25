using AutoMapper;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.Features.Order.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
        }
    }
}
