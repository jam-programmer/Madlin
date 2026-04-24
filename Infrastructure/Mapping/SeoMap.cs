using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class SeoMap : IEntityTypeConfiguration<SeoEntity>
{
    public void Configure(EntityTypeBuilder<SeoEntity> builder)
    {
        builder.ToTable("Seo", "Setting");
        builder.HasData(new SeoEntity()
        {
            Id=Guid.Parse("c41ad831-7a86-4559-cd29-08de6c72b976"),
           
        });
    }
}
