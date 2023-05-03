using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.User.Queries.GetById
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        public IMapper _mapper { get; }
        public IUserRepository _userRepository { get; }
        public IFileRepository _fileRepository { get; }
        public GetUserDetailsQueryHandler(IMapper mapper,
            IUserRepository userRepository, 
            IFileRepository fileRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _fileRepository = fileRepository;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id) ?? throw new
                NotFoundException(nameof(User), request.Id);
            var userFiles= await _fileRepository.GetAsync(new DTOs.File.FileSearchDto { UserId = request.Id });
            user.Files = (ICollection<Domain.File>)userFiles;
            return _mapper.Map<UserDto>(user);
        }
    }
}
