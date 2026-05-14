using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Bank;

public interface IBankService
{  
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Bank"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task InsertBankAsync(BankDto Bank, CancellationToken cancellationToken = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Bank"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task UpdateBankAsync(BankDto Bank, CancellationToken cancellationToken = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task DeleteBankAsync(Guid Id, CancellationToken cancellationToken = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<BankDto> GetBankByIdAsync(Guid Id, CancellationToken cancellationToken = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="pagination"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<PaginatedList<BankDto>> GetBanksAsync(Pagination pagination,
		CancellationToken cancellationToken = default);
}
