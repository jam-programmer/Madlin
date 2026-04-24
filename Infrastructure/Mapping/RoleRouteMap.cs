using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class RoleRouteMap : IEntityTypeConfiguration<RoleRouteEntity>
{
    public void Configure(EntityTypeBuilder<RoleRouteEntity> builder)
    {
        builder.ToTable("RoleRouteMap", "dbo");
        builder.HasOne(o => o.RoleEntity)
            .WithMany(m => m.RoleRoutes)
            .HasForeignKey(f => f.RoleId);


        builder.HasOne(o => o.RouteEntity)
         .WithMany(m => m.RoleRoutes)
         .HasForeignKey(f => f.RouteId);
    }
}
