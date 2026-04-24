using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class ProductCategoryRepository : Repository<CategoryEntity>,
    IProductCategoryRepository
{
    readonly SqlServerContext _context;
    public ProductCategoryRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<CategoryEntity>> GetFeaturedProductCategoriesAsync(CancellationToken cancellation)
    {
        return await _context.Set<CategoryEntity>().Where(w => w.IsFeatured == true).ToListAsync();
    }
    public async Task<List<CategoryEntity>> GetNewestProductCategoriesAsync(CancellationToken cancellation)
    {
        return await _context.Set<CategoryEntity>().OrderByDescending(o => o.CreatedAt)
            .Take(12).Include(i => i.Products).ToListAsync();
    }
    public async Task<Guid> GetCategoryIdByUrlNameAsync(string urlName, CancellationToken cancellation)
    {
        return await _context.Set<CategoryEntity>().Where(w=>w.UrlName == urlName)
            .Select(s=>s.Id)
           .FirstOrDefaultAsync(cancellation);
    }
}
