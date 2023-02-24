using eTaxi.Application.Contracts.Persistence;
using FluentValidation;

namespace eTaxi.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{Property: FirstName} is required")
                .NotNull().WithMessage("{Property: FirstName} must be not null value")
                .MaximumLength(100).WithMessage("{Property: FirstName} must be fewer than 100 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{Property: LastName} is required")
                .NotNull().WithMessage("{Property: LastName} must be not null value")
                .MaximumLength(100).WithMessage("{Property: LastName} must be fewer than 100 characters.");

            RuleFor(p => p)
                .MustAsync(UserEmailUnique)
                 .WithMessage("Email already exist");
        }

        private async Task<bool> UserEmailUnique(CreateUserCommand command, CancellationToken token)
        {
            return await _userRepository.GetUserByEmail(command.Email) == null;
        }
    }
}
