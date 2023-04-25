using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.File;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.File.Queries
{
    public record GetFileQuery(int Id) : IRequest<FileDto>
    {
    }

    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMapper _mapper;
        public GetFileQueryHandler(IFileRepository fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }
        public async Task<FileDto> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Domain.File), request.Id);
            return _mapper.Map<FileDto>(file);
        }
    }
}
