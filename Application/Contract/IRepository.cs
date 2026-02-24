
using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contract;

public interface IRepository<TEntity> where TEntity : BaseEntity 
{
    Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>
        condition);

 
     Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>
        condition,  CancellationToken cancellation = default);




    Task InsertAsync(TEntity entity, CancellationToken cancellation = default);
    Task InsertAsync(List<TEntity> entities, CancellationToken cancellation = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);
    Task UpdateAsync(List<TEntity> entities, CancellationToken cancellation = default);


    Task<bool> ExistAsync(Expression<Func<TEntity, bool>>
        condition, CancellationToken cancellation = default);


    Task DeleteAsync(TEntity entity, CancellationToken cancellation = default);
    Task DeleteAsync(List<TEntity> entities, CancellationToken cancellation = default);


    IQueryable<TEntity> GetByQuery();



}