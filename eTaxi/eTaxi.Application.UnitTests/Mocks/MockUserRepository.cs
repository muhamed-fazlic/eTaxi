using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using Moq;

namespace eTaxi.Application.UnitTests.Mocks
{
    public class MockUserRepository
    {
        public static Mock<IUserRepository> GetMockUserRepository()
        {
            var users = new List<User>
            {
                new User
                {
                    FirstName = "Admin",
                    LastName = "eTaxi",
                    Email = "admin@admin.com",
                },
                new User
                {
                    FirstName = "Muhamed",
                    LastName = "Fazlic",
                    Email = "fazla@admin.com",
                },
                new User
                {
                    FirstName = "Bilal",
                    LastName = "Hodzic",
                    Email = "billy@admin.com",
                }
            };
            var mockRepo = new Mock<IUserRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(users);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<User>()))
                .Returns((User user) =>
                {
                    users.Add(user);
                    return Task.CompletedTask;
                });
            mockRepo.Setup(r => r.GetUserByEmail(It.IsAny<string>())).ReturnsAsync((string email) => users.FirstOrDefault(x => x.Email == email));
            return mockRepo;
        }
    }
}
