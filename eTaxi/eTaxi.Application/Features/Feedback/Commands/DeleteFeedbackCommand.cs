using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.Feedback.Commands
{
    public record DeleteFeedbackCommand(int Id) : IRequest<Unit>
    {
    }

    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Unit>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public async Task<Unit> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);
            await _feedbackRepository.DeleteAsync(feedback);
            return Unit.Value;
        }
    }
}
