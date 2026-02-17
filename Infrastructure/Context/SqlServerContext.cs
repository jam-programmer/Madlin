
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Product;

namespace Infrastructure.Context;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
    { }

    public DbSet<ProductEntity> products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
        base.OnModelCreating(builder);
    }
}

    


