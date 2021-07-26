using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using GenericApi.Bl.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Bl.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<DocumentValidator>();
            });
            return builder;
        }
    }
}
