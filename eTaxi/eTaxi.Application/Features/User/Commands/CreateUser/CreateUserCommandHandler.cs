using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
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
            var userToCreate = _mapper.Map<Domain.User>(request);

            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }
}
