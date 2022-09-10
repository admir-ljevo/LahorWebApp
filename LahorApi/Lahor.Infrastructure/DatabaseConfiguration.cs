using Lahor.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lahor.Infrastructure
{
    public partial class DatabaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            base.OnConfiguring(optionsBuilder);
        }
        private void ConfigureModel(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var isDeletedProperty = entityType.FindProperty(nameof(BaseEntity.IsDeleted));
                if (isDeletedProperty == null)
                    continue;

                var parameter = Expression.Parameter(entityType.ClrType, "p");

                entityType.SetQueryFilter(Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, isDeletedProperty.PropertyInfo),
                        Expression.Constant(false, typeof(bool))
                    ),
                    parameter
                ));
            }
        }

        private void ModifyTimestamps()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = ((IBaseEntity)entry.Entity);

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }

        public override int SaveChanges()
        {
            ModifyTimestamps();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ModifyTimestamps();

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
