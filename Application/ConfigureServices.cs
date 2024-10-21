using Application.Common.behaviours;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // Register MediatR for CQRS
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //validation
                ctg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
            services.AddHttpContextAccessor();
            services.AddMvc().AddSessionStateTempDataProvider();
         
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);// Thời gian session tồn tại
                options.Cookie.HttpOnly = true;// Đảm bảo cookie chỉ có thể truy cập qua HTTP
                options.Cookie.IsEssential = true;// Cần thiết cho hoạt động của ứng dụng
            });
            return services;
        }
    }
}
