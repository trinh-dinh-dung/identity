using Microsoft.Extensions.DependencyInjection;
using System;
using Evo.Mes.Sop.Application.Common.Converters;
using Application.IServices;
using Application.Services;
using Infrastructure.IRepositories;
using Infrastructure.Repositories;
using Application.RabbitMQ;

namespace ApiService.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigDI(this IServiceCollection services)
        {
            // DependencyInjection
            services.AddScoped<IService, Service>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRabbitMQClient, RabbitMQClient>();

            return services;
        }
        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(configAction: cfg =>
            {
                cfg.CreateMap<DateTime?, int?>().ConvertUsing(new DateTimeTypeConverter());
                cfg.CreateMap<DateTime, int>().ConvertUsing(new DateTimeTypeConverter());
                // map tu entity sang getMap
                
            }, AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
