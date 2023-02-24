using eTaxi.Application.Contracts.Email;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Models.Email;
using eTaxi.Infrastructure.EmailService;
using eTaxi.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eTaxi.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

            return services;
        }
    }
}
