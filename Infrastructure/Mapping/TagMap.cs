using Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal class TagMap : IEntityTypeConfiguration<TagEntity>
{
    public void Configure(EntityTypeBuilder<TagEntity> builder)
    {
        builder.ToTable("Tag", "blog");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.HasMany(o => o.BlogTags)
       .WithOne(m => m.Tag)
       .HasForeignKey(f => f.TagId);
    }
}
