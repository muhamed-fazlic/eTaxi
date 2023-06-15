using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using MediatR;


namespace eTaxi.Application.Features.User.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetAsync();
            return _mapper.Map<List<UserDto>>(userList);
        }
    }
}
