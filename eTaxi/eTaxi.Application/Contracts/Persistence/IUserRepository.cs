using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string emailAddress);
    }
}
