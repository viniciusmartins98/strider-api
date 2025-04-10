﻿using Microsoft.Extensions.DependencyInjection;

namespace Strider.BackEnd.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
            return services;
        }
    }
}
