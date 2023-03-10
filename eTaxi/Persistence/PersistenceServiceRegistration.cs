using eTaxi.Application.Contracts.Persistence;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using eTaxi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eTaxi.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,
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
