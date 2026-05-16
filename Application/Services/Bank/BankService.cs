using Application.Common.Extension;
using Domain.Contract;
using Domain.Entities.Sms;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Bank;

public class BankService : IBankService
{
	readonly IBankRepository _bankRepository;
	public BankService(IBankRepository bankRepository)
	{
		_bankRepository = bankRepository;
	}
	public async Task DeleteBankAsync(Guid Id, CancellationToken cancellationToken = default)
	{
		BankEntity entity = await _bankRepository.GetByIdAsync(g => g.Id == Id);
		if (entity == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		entity.IsDeleted = true;
		await _bankRepository.UpdateAsync(entity, cancellationToken);
	}

	public async Task<BankDto> GetBankByIdAsync(Guid Id, CancellationToken cancellationToken = default)
	{
		BankEntity entity = await _bankRepository.GetByIdAsync(g => g.Id == Id);
		if (entity == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		return entity.Adapt<BankDto>();
	}

	public async Task<PaginatedList<BankDto>> GetBanksAsync(Pagination pagination, CancellationToken cancellationToken = default)
	{
		IQueryable<BankEntity> query = _bankRepository.GetByQuery();


		PaginatedList<BankDto> model = new();
		if (!string.IsNullOrEmpty(pagination!.keyword))
		{
			query = query.Where(w =>
				 w.Title!.Contains(pagination!.keyword) ||
				 w.PhoneNumber!.Contains(pagination!.keyword));
		}
		int count = query.Count().PageCount(pagination!.pageSize);
		int total = query.Count();

		model = await query.MappingedAsync<BankEntity, BankDto>
				(pagination!.currentPage,
				pagination!.pageSize, count, total);
		return model;
	}

    public async Task<IReadOnlyList<ItemGeneric<string, string>>> GetNumbersForDropDownAsync(string search)
    {
        IQueryable<BankEntity> query = _bankRepository.GetByQuery();

        if (string.IsNullOrEmpty(search) is false)
        {
            query = query.Where(w => w.PhoneNumber!.Contains(search) ||
            w.Title!.Contains(search));
        }
        return await query
            .Take(10).Select(s => new ItemGeneric<string, string>()
            {
                Id = s.PhoneNumber,
                Title = $"{s.Title} - {s.PhoneNumber}" 
            }).ToListAsync();
    }

    public async Task InsertBankAsync(BankDto Bank, CancellationToken cancellationToken = default)
	{
		BankEntity entity = Bank.Adapt<BankEntity>();
		await _bankRepository.InsertAsync(entity, cancellationToken);
	}

	public async Task UpdateBankAsync(BankDto Bank, CancellationToken cancellationToken = default)
	{
		BankEntity entity = await _bankRepository.GetByIdAsync(g => g.Id == Bank.Id);
		if (entity == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		Bank.Adapt(entity);
		await _bankRepository.UpdateAsync(entity, cancellationToken);
	}
}
