using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IContextProvider
{
	IExecutionStrategy CreateExecutionStrategy();
	Task<IDbContextTransaction> BeginTransactionAsync();
}
