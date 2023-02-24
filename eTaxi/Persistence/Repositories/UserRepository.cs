using AutoMapper;
using eTaxi.Application.Contracts.Persistence;
using eTaxi.Application.DTOs.User;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(TaxiDatabaseContext context,
            IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<UserDto> GetUserByEmail(string emailAddress)
        {
            var user = await _context.User.Where(x => x.Email == emailAddress).FirstOrDefaultAsync();
            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }
    }
}
