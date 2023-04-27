using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Contracts.Photo;
using eTaxi.Application.Models.Photo;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eTaxi.Application.Features.Feedback.Commands
{
    public class CreateFeedbackCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public int OrderId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Grade { get; set; }
    }

    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, int>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository,  IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Domain.Feedback>(request);
            await _feedbackRepository.CreateAsync(feedback);
           
            return feedback.Id;
        }
    }
}
