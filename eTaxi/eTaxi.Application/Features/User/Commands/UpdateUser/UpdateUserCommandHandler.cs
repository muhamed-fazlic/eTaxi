using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using MediatR;

namespace eTaxi.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        public IMapper _mapper { get; }
        public IUserRepository _userRepository { get; }
        public UpdateUserCommandHandler(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, userToUpdate);

            await _userRepository.UpdateAsync(userToUpdate);

            return Unit.Value;
        }
    }
}
