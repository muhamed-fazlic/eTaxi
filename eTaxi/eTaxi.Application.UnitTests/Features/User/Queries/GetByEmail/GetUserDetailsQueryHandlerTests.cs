using AutoMapper;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Application.Features.User.Queries.GetByEmail;
using eTaxi.Application.MappingProfiles;
using eTaxi.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace eTaxi.Application.UnitTests.Features.User.Queries.GetByEmail
{
    public class GetUserDetailsQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetUserDetailsQueryHandler>> _appLogger;

        public GetUserDetailsQueryHandlerTests()
        {
            _mockRepo = MockUserRepository.GetMockUserRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<UserProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _appLogger = new Mock<IAppLogger<GetUserDetailsQueryHandler>>();
        }

        [Fact]
        public async Task GetUsersTest()
        {
            var handler = new GetUserDetailsQueryHandler(_mapper, _mockRepo.Object, _appLogger.Object);

            var result = await handler.Handle(new GetUserDetailsQuery("admin@admin.com"), CancellationToken.None);

            result.ShouldBeOfType<UserDto>();
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task GetUsersTestNewEmail_Fail()
        {
            var handler = new GetUserDetailsQueryHandler(_mapper, _mockRepo.Object, _appLogger.Object);

            var result = await handler.Handle(new GetUserDetailsQuery("new@gmail.com"), CancellationToken.None);

            result.ShouldBeOfType<UserDto>();
            result.ShouldNotBeNull();
        }
    }
}
