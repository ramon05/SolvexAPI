using Microsoft.Extensions.DependencyInjection;
using GenericApi.Model.Interfaces;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IWorkShopRepository, WorkShopRepository>();
            services.AddScoped<IWorkShopDayRepository, WorkShopDayRepository>();
            services.AddScoped<IWorkShopMemberRepository, WorkShopMemberRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
