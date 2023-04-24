using AutoMapper;
using eTaxi.Application.DTOs.Order;
using eTaxi.Application.Features.Order.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
        }
    }
}
