using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class MessageMap :
    IEntityTypeConfiguration<MessageEntity>
{
    public void Configure(EntityTypeBuilder<MessageEntity> builder)
    {
        builder.ToTable("Message", "dbo");
        builder.HasQueryFilter(f=>f.IsDeleted==false);
        builder.Property(p=>p.CreatedAt).HasDefaultValue(DateTime.Now);
    }
}
