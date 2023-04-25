using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Contracts.Photo;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.File.Commands
{
    public class DeleteFileCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Unit>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IPhotoServer _photoServer;
        public DeleteFileCommandHandler(IFileRepository fileRepository, IPhotoServer photoServer)
        {
            _fileRepository = fileRepository;
            _photoServer = photoServer;
        }
        public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetByIdAsync(request.Id);
            if (file == null)
            {
                throw new NotFoundException(nameof(Domain.File), request.Id);
            }
            _photoServer.RemoveImage(request.Name, request.Url);
            await _fileRepository.DeleteAsync(file);
            return Unit.Value;
        }
    }
}
