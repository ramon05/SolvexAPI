using Microsoft.EntityFrameworkCore;
using GenericApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GenericApi.Model.Extensions
{
    public static class EntityFrameworkModelBuilderExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType).Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EntityFrameworkModelBuilderExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : class, IBase
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.Deleted);
        }
    }
}
