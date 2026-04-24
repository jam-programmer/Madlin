using Domain.Contract;
using Domain.Entities.Blog;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class BlogCategoryRepository : Repository<CategoryEntity>, IBlogCategoryRepository
{
    readonly SqlServerContext _context;
    public BlogCategoryRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<Guid> GetCategoryIdByUrlNameAsync(string urlName)
    {
        return await _context.Set<CategoryEntity>()
            .Where(w=>w.UrlName == urlName).Select(s => s.Id).FirstOrDefaultAsync();
    }
}
