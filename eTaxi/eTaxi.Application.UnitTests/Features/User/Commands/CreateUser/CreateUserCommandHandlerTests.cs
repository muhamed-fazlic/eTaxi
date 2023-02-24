using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.Features.User.Commands.CreateUser;
using eTaxi.Application.Features.User.Queries.GetByEmail;
using eTaxi.Application.MappingProfiles;
using eTaxi.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace eTaxi.Application.UnitTests.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<CreateUserCommandHandler>> _appLogger;

        public CreateUserCommandHandlerTests()
        {
            _mockRepo = MockUserRepository.GetMockUserRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<UserProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _appLogger = new Mock<IAppLogger<CreateUserCommandHandler>>();
        }

        [Fact]
        public async Task CreateUser()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object, _appLogger.Object);
            await handler.Handle(new CreateUserCommand() { Email = "hello@world.com", FirstName = "Test", LastName = "Test" }, CancellationToken.None);
        }

        [Fact]
        public async Task CreateUserWithExistingEmail_Fail()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object, _appLogger.Object);
            await handler.Handle(new CreateUserCommand() { Email = "admin@admin.com", FirstName = "Test", LastName = "Test" }, CancellationToken.None);
        }
    }
}
