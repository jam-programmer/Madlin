using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class PictureMap : IEntityTypeConfiguration<PictureEntity>
{
    public void Configure(EntityTypeBuilder<PictureEntity> builder)
    {
        builder.ToTable("Picture", "Product");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasOne(o => o.Product)
            .WithMany(m => m.Pictures)
            .HasForeignKey(f => f.ProductId);
    }
}
