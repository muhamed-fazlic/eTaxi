using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IMapper mapper,
            IUserRepository userRepository,
            IAppLogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validation errors in insert requrest for {0}", nameof(Domain.User));
                throw new BadRequestException("Invalid user data", validationResult);
            }

            var userToCreate = _mapper.Map<Domain.User>(request);

            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }
}
