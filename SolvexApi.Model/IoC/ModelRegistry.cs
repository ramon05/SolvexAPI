using Microsoft.Extensions.DependencyInjection;
using SolvexApi.Model.Interfaces;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.IoC
{
    public static class ModelRegistry
    {
        public static void AddModelRegistry(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IWorkShopRepository, WorkShopRepository>();
            services.AddScoped<IWorkShopDayRepository, WorkShopDayRepository>();
            services.AddScoped<IWorkShopMemberRepository, WorkShopMemberRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
        }
    }
}
