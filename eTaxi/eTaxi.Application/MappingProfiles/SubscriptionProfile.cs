using AutoMapper;
using eTaxi.Application.DTOs.Subscription;
using eTaxi.Application.Features.Rating.Commands;
using eTaxi.Application.Features.Subscription.Commands;
using eTaxi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxi.Application.MappingProfiles
{
    public class SubscriptionProfile:Profile
    {
        public SubscriptionProfile()
        { 
            CreateMap<SubscriptionDto, Subscription>().ReverseMap();
            CreateMap<CreateSubscriptionCommand, Subscription>().ReverseMap();
            CreateMap<UpdateSubscriptionCommand, Subscription>().ReverseMap();

        }
    }
}
