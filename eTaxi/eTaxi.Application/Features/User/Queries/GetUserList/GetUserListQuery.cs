using eTaxi.Application.DTOs.User;
using MediatR;


namespace eTaxi.Application.Features.User.Queries.GetUserList
{
    public class GetUserListQuery:IRequest<List<UserDto>>
    {
        public UserSearchDto Search { get; set; }
    }
}
