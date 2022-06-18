using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Master.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Master.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddDbContext(configuration);
            return services;
        }
    }
}