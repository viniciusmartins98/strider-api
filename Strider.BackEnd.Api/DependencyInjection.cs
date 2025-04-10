﻿using Strider.BackEnd.Application;
using Strider.BackEnd.Infra;

namespace Strider.BackEnd.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services) {
            return services
                    .AddApplication()
                    .AddInfra();
        }
    }
}
