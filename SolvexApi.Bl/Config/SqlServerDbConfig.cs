using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GenericApi.Model.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Config
{
    public static class SqlServerDbConfig
    {
        public static IServiceCollection ConfigSqlServerDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<WorkShopDbContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
