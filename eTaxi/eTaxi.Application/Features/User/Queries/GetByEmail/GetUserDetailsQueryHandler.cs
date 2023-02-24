using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.User.Queries.GetByEmail
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<GetUserDetailsQueryHandler> _logger;
        public GetUserDetailsQueryHandler(IMapper mapper,
            IUserRepository userRepository,
            IAppLogger<GetUserDetailsQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.emailAddress) ?? throw new
                NotFoundException(nameof(User), request.emailAddress);

            var mappedUser = _mapper.Map<UserDto>(user);

            _logger.LogInformation("User retrieved successfully");
            return mappedUser;
        }
    }
}
