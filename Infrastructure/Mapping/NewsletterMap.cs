using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class NewsletterMap : IEntityTypeConfiguration<NewsletterEntity>
{
    public void Configure(EntityTypeBuilder<NewsletterEntity> builder)
    {
        builder.ToTable("Newsletter", "dbo");
    }
}
