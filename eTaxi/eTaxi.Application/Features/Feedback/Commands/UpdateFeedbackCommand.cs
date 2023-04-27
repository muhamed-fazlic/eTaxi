using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Feedback.Commands
{
    public class UpdateFeedbackCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
    }

    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, Unit>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, feedback);
            await _feedbackRepository.UpdateAsync(feedback);
            return Unit.Value;
        }
    }
}
