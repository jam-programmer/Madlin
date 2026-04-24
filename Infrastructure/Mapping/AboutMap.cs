using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class AboutMap : IEntityTypeConfiguration<AboutEntity>
{
    public void Configure(EntityTypeBuilder<AboutEntity> builder)
    {
        builder.ToTable("About", "Setting");
        builder.HasData(new AboutEntity()
        {
            Id = Guid.Parse("c11cc931-6a66-1249-bd81-12de6c72b976"),
            ImagePath = "default.jpg",
            TextFa = string.Empty,
            TextEn = string.Empty,
        });
    }
}
