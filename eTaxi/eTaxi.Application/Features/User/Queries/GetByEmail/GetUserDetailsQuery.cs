using eTaxi.Application.DTOs.User;
using MediatR;

namespace eTaxi.Application.Features.User.Queries.GetByEmail
{
    public record GetUserDetailsQuery(string emailAddress) : IRequest<UserDto>;
}
