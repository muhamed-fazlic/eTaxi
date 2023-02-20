using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext.TaxiDatabaseContext;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServoce(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TaxiDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("eTaxiConnectionString"));
            });
            return services;
        }
    }
}
