using eTaxi.Application.Contracts.Email;
using eTaxi.Application.Contracts.Logging;
using eTaxi.Application.Contracts.Stripe;
using eTaxi.Application.Models.Email;
using eTaxi.Infrastructure.EmailService;
using eTaxi.Infrastructure.Logging;
using eTaxi.Infrastructure.StripeService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

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

            //configure stripe services
            StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSettings:SecretKey");
            services
                  .AddScoped<CustomerService>()
                  .AddScoped<ChargeService>()
                  .AddScoped<TokenService>()
                  .AddScoped<IStripeAppService, StripeAppService>();
            return services;
        }
    }
}
