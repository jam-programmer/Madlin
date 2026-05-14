using Domain.Contract;
using Domain.Entities.Sms;
using Infrastructure.Context;

namespace Infrastructure.Implement;

public class BankRepository : Repository<BankEntity>, IBankRepository
{
	readonly SqlServerContext _context;
	public BankRepository(SqlServerContext context) : base(context)
	{
		_context = context;
	}
}
