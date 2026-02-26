using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class FeatureMap : IEntityTypeConfiguration<FeatureEntity>
{
    public void Configure(EntityTypeBuilder<FeatureEntity> builder)
    {
        builder.ToTable("Feature", "Product");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasOne(o => o.Product)
            .WithMany(m => m.Features)
            .HasForeignKey(f => f.ProductId);
    }
}
