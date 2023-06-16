using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Exceptions;
using eTaxi.Application.Features.Favorite.Queries;
using eTaxi.Application.Features.Rating.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eTaxi.Application.Features.User.Queries.GetById
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        public IMapper _mapper { get; }
        public IUserRepository _userRepository { get; }
        public IFileRepository _fileRepository { get; }
        public IFavoriteRepository _favoriteRepository { get; }
        public IRatingRepository _ratingRepository { get; }
        private readonly UserManager<Domain.User> _userManager;
        public GetUserDetailsQueryHandler(IMapper mapper,
            IUserRepository userRepository,
            IFileRepository fileRepository,
            IFavoriteRepository favoriteRepository,
            IRatingRepository ratingRepository,
            UserManager<Domain.User> userManager
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _fileRepository = fileRepository;
            _favoriteRepository = favoriteRepository;
            _ratingRepository = ratingRepository;
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id) ?? throw new
                NotFoundException(nameof(User), request.Id);

            var roles = await _userManager.GetRolesAsync(user);

            var userFiles = await _fileRepository.GetAsync(new DTOs.File.FileSearchDto { UserId = request.Id });
            user.Files = (ICollection<Domain.File>)userFiles;

            var userFavorites = await _favoriteRepository.GetAsync(new GetFavoriteListQuery { UserId = request.Id });
            user.Favorites = (ICollection<Domain.Favorite>)userFavorites;

            var userRatings = await _ratingRepository.GetAsync(new DTOs.Rating.RatingSearchDto { UserDriverId = request.Id });
            var averageGrades = userRatings
            .GroupBy(r => r.UserDriverId)
            .Select(g => new { RatingGrade = g.Average(r => r.Grade), Count = g.Count() });

            UserDto mappedUser = _mapper.Map<UserDto>(user);
            mappedUser.RatingGrade = averageGrades;
            mappedUser.UserType = roles.FirstOrDefault();

            return mappedUser;
        }
    }
}
