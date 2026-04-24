using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class WishMap : IEntityTypeConfiguration<WishEntity>
{
    public void Configure(EntityTypeBuilder<WishEntity> builder)
    {
        builder.ToTable("Wish", "Product");
        builder.HasOne(o => o.User)
            .WithMany(m => m.Wishes)
            .HasForeignKey(f => f.UserId);

        builder.HasOne(o => o.Product)
     .WithMany(m => m.Wishes)
     .HasForeignKey(f => f.ProductId);
    }
}
