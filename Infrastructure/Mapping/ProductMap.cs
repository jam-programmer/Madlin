using Microsoft.EntityFrameworkCore;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Mapping;

internal sealed class ProductMap : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {   
        builder.ToTable("Product", "Product");
        builder.Property(p => p.MainImagePath).HasDefaultValue("default.jpg");
        builder.Property(p => p.HoverImagePath).HasDefaultValue("default.jpg");

        builder.Property(p=>p.TitleEn).IsRequired().HasMaxLength(200);
        builder.Property(p=>p.TitleFa).IsRequired().HasMaxLength(250);
        builder.Property(p=>p.ShortDescriptionEn).IsRequired();
        builder.Property(p=>p.ShortDescriptionFa).IsRequired();
        builder.Property(p => p.FullDescriptionEn).IsRequired();
        builder.Property(p => p.FullDescriptionFa).IsRequired();
        builder.HasIndex(p => p.ProductCode).IsUnique();
        builder.Property(p => p.Price).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.DiscountPrice).HasPrecision(18, 2);
      

        builder.HasOne(o => o.Category)
            .WithMany(m => m.Products)
            .HasForeignKey(f => f.CategoryId);
        builder.HasQueryFilter(f=>f.IsDeleted==false);
    }
}
