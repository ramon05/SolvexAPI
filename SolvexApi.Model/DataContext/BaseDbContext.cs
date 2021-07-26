using GenericApi.Model.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GenericApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericApi.Model.DataContext
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }

    public abstract class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        private void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (entry.Entity.Id > 0)
                        {
                            entry.State = EntityState.Modified;
                            goto case EntityState.Modified;
                        }

                        entry.Entity.Deleted = false;
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.UpdatedDate = DateTimeOffset.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        entry.Entity.DeletedDate = DateTimeOffset.UtcNow;
                        break;

                    default:
                        break;
                }
            }
        }

        public override int SaveChanges()
        {
            SetAuditEntities();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            SetAuditEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBase).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }
    }
}
