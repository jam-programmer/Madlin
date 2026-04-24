using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class GeneralMap : IEntityTypeConfiguration<GeneralEntity>
{
    public void Configure(EntityTypeBuilder<GeneralEntity> builder)
    {
        builder.ToTable("General", "Setting");
        builder.HasData(new GeneralEntity()
        {
            Id=Guid.Parse("c11cc931-7a86-4239-bd29-08de6c72b976"),
            AddressEn=string.Empty,
            AddressFa=string.Empty,
            Email=string.Empty,
            Instagram=string.Empty,
            Linkedin=string.Empty,
            LogoPath=string.Empty,
            FaviconPath= string.Empty,
            PhoneNumber=string.Empty,
            Telegram=string.Empty,
            TitleEn=string.Empty,   
            TitleFa=string.Empty,
            WhatsApp = string.Empty,
            DescriptionEn=string.Empty,
            DescriptionFa   = string.Empty
        });
    }
}
