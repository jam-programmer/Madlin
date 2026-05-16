using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class EventImageMap : IEntityTypeConfiguration<EventImageEntity>
{
    public void Configure(EntityTypeBuilder<EventImageEntity> builder)
    {
        builder.ToTable("EventImage", "dbo");
        builder.HasOne(o => o.Event)
            .WithMany(m => m.EventImages)
            .HasForeignKey(f => f.EventId);
    }
}
