using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.Feedback;
using eTaxi.Application.Exceptions;
using MediatR;
using System.Security.Policy;

namespace eTaxi.Application.Features.Feedback.Queries
{
    public record GetFeedbackQuery(int Id) : IRequest<FeedbackDto>
    {
    }

    public class GetFeedbackQueryHandler : IRequestHandler<GetFeedbackQuery, FeedbackDto>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;

        public GetFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper, IFileRepository fileRepository)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
            _fileRepository = fileRepository;
        }

        public async Task<FeedbackDto> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Feedback), request.Id);
            var feedbackFiles=await _fileRepository.GetAsync(new DTOs.File.FileSearchDto() { FeedbackId=request.Id});
            feedback.Files = (ICollection<Domain.File>)feedbackFiles;
            return _mapper.Map<FeedbackDto>(feedback);
        }
    }

}
