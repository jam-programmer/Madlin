using Domain.Entities.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class BankMap : IEntityTypeConfiguration<BankEntity>
{
	public void Configure(EntityTypeBuilder<BankEntity> builder)
	{
		builder.ToTable("Bank", "sms");
		builder.HasQueryFilter(f => f.IsDeleted == false);
	}
}
