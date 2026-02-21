
using Domain.Entities;
using Domain.Entities.Identity;
using Infrastructure.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Infrastructure.Context;

public class SqlServerContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserEntity>().HasQueryFilter(f=>f.IsDeleted==false);
        builder.Entity<RoleEntity>().HasQueryFilter(f=>f.IsDeleted==false);
        builder.AppendDbSetOfEntity();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    public override int SaveChanges()
    {
        IEnumerable<EntityEntry> entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Modified);

        DateTime updateTime = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.Entity is IUpdate entity)
            {
                entity.UpdatedAt = updateTime;
            }
        }

        return base.SaveChanges();
    }
}




