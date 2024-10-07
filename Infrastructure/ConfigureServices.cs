using FlightSystem.Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
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
            //đăng kí database
            services.AddDbContext<FlightSystemDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
            );
            //đăng kí service
            services.AddScoped<IUserService, UserRepository>();
            services.AddScoped<IGroupService, GroupRepository>();
            services.AddScoped<IAccountService, AccountRepository>();
            services.AddScoped<IFlightService, FlightRepository>();
            services.AddScoped<IFileStorageService, FileStorageRepository>();
            services.AddScoped<IDocumentService, DocumentRepository>();
            services.AddScoped<IDocumentTypeService, DocumentTypeRepository>();
            services.AddScoped<IGroupDocumentService, GroupDocumentRepository>();
            services.AddScoped<IGroupDocumentTypeService, GroupDocumentTypeRepository>();
            return services;
        }
    }
}

