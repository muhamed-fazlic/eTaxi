using eTaxi.Application.DTOs.User;
using eTaxi.Domain;

namespace eTaxi.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<UserDto> GetUserByEmail(string emailAddress);
    }
}
