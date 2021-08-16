using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using GenericApi.Model.DataContext;

namespace GenericApi.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection ConfigIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<WorkShopDbContext>()
                 .AddDefaultTokenProviders();
            return services;
        }
    }
}
