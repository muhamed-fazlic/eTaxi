using MediatR;

namespace eTaxi.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
