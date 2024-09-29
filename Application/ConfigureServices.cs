using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            var assemly = typeof(ConfigureServices).Assembly;
            service.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assemly));
            service.AddValidatorsFromAssembly(assemly);
            return service;
        }
    }
}
