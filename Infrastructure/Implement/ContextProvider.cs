using Application.Contract;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class ContextProvider: IContextProvider
{
	readonly SqlServerContext _context;
    public ContextProvider(SqlServerContext context)
    {
        _context = context;
    }

	public async Task<IDbContextTransaction> BeginTransactionAsync()
	{
		return await _context.Database.BeginTransactionAsync();	
	}

	public IExecutionStrategy CreateExecutionStrategy()
	{
		return _context.Database.CreateExecutionStrategy();

	}
}
