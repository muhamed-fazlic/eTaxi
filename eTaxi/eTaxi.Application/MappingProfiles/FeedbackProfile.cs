using AutoMapper;
using eTaxi.Application.DTOs.Feedback;
using eTaxi.Application.Features.Feedback.Commands;
using eTaxi.Domain;

namespace eTaxi.Application.MappingProfiles
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackDto, Feedback>().ReverseMap();
            CreateMap<CreateFeedbackCommand, Feedback>().ReverseMap();
            CreateMap<UpdateFeedbackCommand, Feedback>().ReverseMap();
        }
    }
}
