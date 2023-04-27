using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Contracts.Photo;
using eTaxi.Application.Models.Photo;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace eTaxi.Application.Features.File.Commands
{
    public class CreateFileCommand : IRequest<int>
    {
        public IFormFile File { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public int? FeedbackId { get; set; }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, int>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IPhotoServer _photoService;
        private readonly IMapper _mapper;
        public CreateFileCommandHandler(IFileRepository fileRepository, IPhotoServer photoService, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _photoService = photoService;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = new Domain.File();
            PhotoResponse photo = _photoService.UploadPhoto<dynamic>(request.File, "test");
            file = _mapper.Map<Domain.File>(photo);
            file.Type = request.Type;
            file.UserId = request.UserId;
            file.FeedbackId=request.FeedbackId;
            await _fileRepository.CreateAsync(file);
            return file.Id;
        }
    }
}
