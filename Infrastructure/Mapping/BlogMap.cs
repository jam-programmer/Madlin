using Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class BlogMap : IEntityTypeConfiguration<BlogEntity>
{
    public void Configure(EntityTypeBuilder<BlogEntity> builder)
    {
        builder.ToTable("Blog", "blog");
        builder.HasQueryFilter(f=>f.IsDeleted==false);
        builder.HasOne(o => o.Category)
            .WithMany(m => m.Blogs)
            .HasForeignKey(f => f.CategoryId);


        builder.HasOne(o => o.User)
         .WithMany(m => m.Blogs)
         .HasForeignKey(f => f.UserId);
        builder.HasMany(o => o.BlogTags)
         .WithOne(m => m.Blog)
         .HasForeignKey(f => f.BlogId);
    }
}
