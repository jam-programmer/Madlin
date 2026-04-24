using Domain.Contract;
using Domain.Entities.Blog;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class TagRepository : Repository<TagEntity>, ITagRepository
{
    readonly SqlServerContext _context;
    public TagRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<Guid>> GetBlogIdsByTagAsync(string key)
    {

        return await _context.Set<TagEntity>()
            .Where(t => t.Key == key)
                .SelectMany(t => t.BlogTags.Select(bt => bt.BlogId))
                        .ToListAsync();
    }
    public async Task<IList<TagEntity>> GetTagsByBlogIdAsync(Guid blogId)
    {
        return await _context.Set<BlogTagEntity>()
            .Where(w=>w.BlogId == blogId)
            .Select(s=>s.Tag).ToListAsync();
    }
}
