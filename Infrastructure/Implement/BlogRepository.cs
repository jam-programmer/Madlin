using Domain.Contract;
using Domain.Entities.Blog;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class BlogRepository :
    Repository<BlogEntity>, IBlogRepository 
{
    readonly SqlServerContext _context;
    public BlogRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<BlogEntity> GetByIdAndJoinAsync(Guid id, CancellationToken cancellation = default)
    {

        return await _context.Set<BlogEntity>().Include(i => i.Category).FirstOrDefaultAsync(w => w.Id == id, cancellation);
    }


    public async Task<IList<BlogEntity>> GetNewestBlogsAsync(int take,CancellationToken cancellation = default)
    {
        return await _context.Set<BlogEntity>().Include(i => i.Category)
            .OrderByDescending(o=>o.CreatedAt).Take(take).ToListAsync();
    }
}
