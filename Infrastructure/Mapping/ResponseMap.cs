using Azure;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ResponseMap :
    IEntityTypeConfiguration<ResponseEntity>
{
    public void Configure(EntityTypeBuilder<ResponseEntity> builder)
    {
        builder.ToTable("Response", "Product");
        builder.HasOne(o => o.Comment)
            .WithOne(o => o.Response)
            .HasForeignKey<ResponseEntity>(f => f.CommentId);
    }
}
