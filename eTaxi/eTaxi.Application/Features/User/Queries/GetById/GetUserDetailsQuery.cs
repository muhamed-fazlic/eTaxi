using eTaxi.Application.DTOs.User;
using MediatR;

namespace eTaxi.Application.Features.User.Queries.GetById
{
    public record GetUserDetailsQuery(int UserId) : IRequest<UserDto>;
}
