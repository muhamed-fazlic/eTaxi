using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User, object>
    {
        Task<User> GetUserByEmail(string emailAddress);
    }
}
