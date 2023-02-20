using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Exceptions;
using MediatR;

namespace eTaxi.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public IMapper _mapper { get; }
        public IUserRepository _userRepository { get; }
        public CreateUserCommandHandler(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid user data", validationResult);

            var userToCreate = _mapper.Map<Domain.User>(request);

            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }
}
