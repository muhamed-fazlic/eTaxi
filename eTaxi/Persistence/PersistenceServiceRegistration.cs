using eTaxi.Application.Contracts.Persistence;
using eTaxi.Domain;
using eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext;
using eTaxi.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
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
                options.UseSqlServer(configuration.GetConnectionString("eTaxiConnectionStringDocker"));
            });

            //  services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IHubStationRepository, HubStationRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IMaliciousUserRepository, MaliciousUserRepository>();

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<TaxiDatabaseContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
