using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stayzee.Application.ServiceContract;
using Stayzee.Application.Services;

namespace Stayzee.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Regiseter Services
            services.AddTransient<IVillaService, VillaService>();
            return services;
        }
    }
}
