using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TaxiDatabaseContext context) : base(context)
        {
        }
        public async Task<User> GetUserByEmail(string emailAddress)
        {
            var user = await _context.ApplicationUser.Where(x => x.Email == emailAddress).FirstOrDefaultAsync();
            if (user == null)
                return null;

            return user;
        }
    }
}
