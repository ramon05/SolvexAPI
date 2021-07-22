using SolvexApi.Core.Adstract;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace SolvexApi.Bl.Extensions
{
    public static class EntityOperationResultExtensions
    {
        public static IEntityOperationResult<TDto> ToOperationResult<TDto>(this TDto dto)
        {
            return new EntityOperationResult<TDto>(dto);
        }

        public static IEntityOperationResult<TDto> ToOperationResult<TDto>(this FluentValidation.Results.ValidationResult validationResult)
        {
            return new EntityOperationResult<TDto>
            {
                Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
            };
        }
    }
}
