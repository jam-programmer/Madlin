using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class HeaderMap : IEntityTypeConfiguration<HeaderEntity>
{
    public void Configure(EntityTypeBuilder<HeaderEntity> builder)
    {
        builder.ToTable("Header", "Setting");
        builder.HasData(new HeaderEntity()
        {
            Id = Guid.Parse("a1b4d3c4-e7f6-4a6b-8e5f-0e3f2b3b4c8d"),
            BlogTitleEn = string.Empty,
            BlogTitleFa = string.Empty,
            CategoryTitleEn = string.Empty,
            CategoryTitleFa = string.Empty,
            GalleryTitleEn = string.Empty,
            GalleryTitleFa = string.Empty,
            ProductTitleEn = string.Empty,
            ProductTitleFa = string.Empty,
            SliderTextEn = string.Empty,
            SliderTextFa = string.Empty,
            SliderTitleEn = string.Empty,
            SliderTitleFa = string.Empty
        });
    }
}
