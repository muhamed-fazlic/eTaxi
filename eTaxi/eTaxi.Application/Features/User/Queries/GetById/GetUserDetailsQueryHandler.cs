using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Features.Favorite.Queries;
using MediatR;

namespace eTaxi.Application.Features.User.Queries.GetById
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        public IMapper _mapper { get; }
        public IUserRepository _userRepository { get; }
        public IFileRepository _fileRepository { get; }
        public IFavoriteRepository _favoriteRepository { get; }
        public GetUserDetailsQueryHandler(IMapper mapper,
            IUserRepository userRepository, 
            IFileRepository fileRepository,
            IFavoriteRepository favoriteRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _fileRepository = fileRepository;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id) ?? throw new
                NotFoundException(nameof(User), request.Id);
            var userFiles= await _fileRepository.GetAsync(new DTOs.File.FileSearchDto { UserId = request.Id });
            user.Files = (ICollection<Domain.File>)userFiles;
            var userFavorites= await _favoriteRepository.GetAsync(new GetFavoriteListQuery { UserId = request.Id });
            user.Favorites = (ICollection<Domain.Favorite>)userFavorites;
            return _mapper.Map<UserDto>(user);  
        }
    }
}
