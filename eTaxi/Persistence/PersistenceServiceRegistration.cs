using eTaxi.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext.TaxiDatabaseContext;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServoce(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TaxiDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("eTaxiConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
