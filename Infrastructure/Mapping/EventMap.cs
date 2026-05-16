using Domain.Entities.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace Infrastructure.Mapping;

internal sealed class EventMap : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("Event", "dbo");
        builder.HasQueryFilter(f => f.IsDeleted == false);
        builder.Property(p => p.VideoUrls)
            .HasConversion(v=>JsonSerializer.Serialize(v,(JsonSerializerOptions?)null),
            v=>JsonSerializer.Deserialize<List<string>>(v,(JsonSerializerOptions?)null) ??new());
    }
}
