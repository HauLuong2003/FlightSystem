using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure
           (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<FlightSystemDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );

            //services.AddTransient<IBlogRepository, BlogRepository>();
            return services;

        }
    }
}

