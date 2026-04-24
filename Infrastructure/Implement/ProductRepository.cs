using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    readonly SqlServerContext _context;
    public ProductRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<ProductEntity>> GetNewestProductsAsync(CancellationToken cancellation = default)
    {
        return await _context.Set<ProductEntity>().OrderByDescending(o => o.CreatedAt)
            .Take(4).ToListAsync();
    }
    public async Task<IList<ProductEntity>> GetProductsForSliderAsync(CancellationToken cancellation = default)
    {
        return await _context.Set<ProductEntity>().Where(w => w.IsShowSlider == true).ToListAsync();
    }
}
