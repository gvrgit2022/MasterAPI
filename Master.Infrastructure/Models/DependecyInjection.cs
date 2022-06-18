using Master.Infrastructure.Models.Common;
using Master.Infrastructure.Models.Master;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Master.Infrastructure.Models
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services.AddDbContext<MasterContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString(Constants.Configuration.MasterDBConnectionString));
                options.EnableSensitiveDataLogging();
            });
            return services;

        }
    }
}
