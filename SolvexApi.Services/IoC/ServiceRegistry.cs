using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using GenericApi.Services.Services;

namespace GenericApi.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IWorkShopService, WorkShopService>();
            services.AddScoped<IWorkShopDayService, WorkShopDayService>();
            services.AddScoped<IWorkShopMemberService, WorkShopMemberService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
