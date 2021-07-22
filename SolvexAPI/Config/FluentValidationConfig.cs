using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SolvexApi.Bl.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolvexAPI.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<DocumentValidator>();
                x.RegisterValidatorsFromAssemblyContaining<WorkShopValidator>();
                x.RegisterValidatorsFromAssemblyContaining<WorkShopDayValidator>();
                x.RegisterValidatorsFromAssemblyContaining<MemberValidator>();
                x.RegisterValidatorsFromAssemblyContaining<WorkShopMemberValidator>();
            });
            return builder;
        }
    }
}
