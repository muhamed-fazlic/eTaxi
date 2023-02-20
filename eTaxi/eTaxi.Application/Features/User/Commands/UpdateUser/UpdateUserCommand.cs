using MediatR;

namespace eTaxi.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
