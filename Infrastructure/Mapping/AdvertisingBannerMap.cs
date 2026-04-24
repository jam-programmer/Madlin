using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class AdvertisingBannerMap :
    IEntityTypeConfiguration<AdvertisingBannerEntity>
{
    public void Configure(EntityTypeBuilder<AdvertisingBannerEntity> builder)
    {
        builder.ToTable("AdvertisingBanner", "dbo");
        builder.HasData(new AdvertisingBannerEntity()
        {

            Id = Guid.Parse("a1b4c3d4-e7f6-4a6b-8c5d-0e3f2a3b4c5d"),
            ImageOnePath = "default.jpg",
            ImageTwoPath = "default.jpg"
        });
    }
}
