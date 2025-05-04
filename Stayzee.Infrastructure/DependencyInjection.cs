using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stayzee.Application.RepositoryContract;
using Stayzee.Infrastructure.Data;
using Stayzee.Infrastructure.Repository;

namespace Stayzee.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            //register db context
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection")));

            // Regiseter Services
            services.AddTransient<IVillaRepository,VillaRepository>();
            return services;
        }

    }
}
