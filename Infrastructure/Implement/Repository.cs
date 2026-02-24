using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Application.Contract;
using Domain.Entities;
namespace Infrastructure.Implement;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{

    private readonly SqlServerContext _context;


    public Repository(SqlServerContext context)
    {
        _context = context;
    }

    private async Task SaveChanges(CancellationToken cancellation = default) => await _context.SaveChangesAsync(cancellation);


    public async Task DeleteAsync(TEntity entity, CancellationToken cancellation = default)
    {
        _context.Remove(entity);
        await SaveChanges(cancellation);
    }

    public async Task DeleteAsync(List<TEntity> entities, CancellationToken cancellation = default)
    {
        _context.RemoveRange(entities);
        await SaveChanges(cancellation);
    }

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> condition, CancellationToken cancellation = default)
    {
        return await _context.Set<TEntity>().AnyAsync(condition);
    }

    public async Task<TEntity> GetByIdAsync
        (Expression<Func<TEntity, bool>> condition)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(condition);
    }

   


    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> condition, CancellationToken cancellation = default)
    {
        return await _context.Set<TEntity>().Where(condition).ToListAsync();

    }




    public async Task InsertAsync(TEntity entity, CancellationToken cancellation = default)
    {
        await _context.Set<TEntity>().AddAsync(entity, cancellation);
        await SaveChanges(cancellation);
    }

    public async Task InsertAsync(List<TEntity> entities, CancellationToken cancellation = default)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities, cancellation);
        await SaveChanges(cancellation);
    }

    public IQueryable<TEntity> GetByQuery()
    {
        return _context.Set<TEntity>().AsQueryable();
    }


    public async Task UpdateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        _context.Update(entity);
        await SaveChanges(cancellation);
    }

    public async Task UpdateAsync(List<TEntity> entities, CancellationToken cancellation = default)
    {
        _context.UpdateRange(entities);
        await SaveChanges(cancellation);
    }

   

   
}