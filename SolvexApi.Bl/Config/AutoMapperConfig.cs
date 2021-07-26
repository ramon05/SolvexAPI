using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Config
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection configAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
