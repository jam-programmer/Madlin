using Domain.Contract;
using Domain.Entities.Blog;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class BlogTagRepository : Repository<BlogTagEntity>, IBlogTagRepository
{
    readonly SqlServerContext _context;
    public BlogTagRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Guid>> GetKeyTagsByBlogIdAsync(Guid blogId, CancellationToken cancellation = default)
    {
        return await _context.Set<BlogTagEntity>().Where(w => w.BlogId == blogId).AsNoTracking()
            .Select(s => s.TagId).ToListAsync(cancellation);
    }
    public async Task DeleteTagsByBlogIdAsync(Guid blogId, CancellationToken cancellation = default)
    {
        await _context.Set<BlogTagEntity>().Where(w => w.BlogId == blogId)
            .ExecuteDeleteAsync(cancellation);
    }


    public async Task<List<BlogTagEntity>> GetTagsByBlogIdAsync(Guid blogId, CancellationToken cancellation)
    {
        return await _context.Set<BlogTagEntity>().Where(w => w.BlogId == blogId).Include(i=>i.Tag).AsNoTracking()
           .ToListAsync(cancellation);
    }
}
