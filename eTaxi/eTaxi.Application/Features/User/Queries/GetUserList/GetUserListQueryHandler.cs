using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eTaxi.Application.Features.User.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.User> _userManager;

        public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper, UserManager<Domain.User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<List<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _userRepository.GetAsync();

            //make a list of roles for each user
            var userlistRoles=new List<string>();
            foreach (var user in userList)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userlistRoles.Add(roles.FirstOrDefault());
            }

            var userDtoList = _mapper.Map<List<UserDto>>(userList);

            for(var i = 0; i<userDtoList.Count; i++)
            {
                userDtoList[i].UserType = userlistRoles[i];
            }
            return userDtoList;
        }
    }
}
