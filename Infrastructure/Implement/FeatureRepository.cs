using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class FeatureRepository : Repository<FeatureEntity>, IFeatureRepository
{
    readonly SqlServerContext _context;
    public FeatureRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<FeatureEntity>> GetFeaturesByProductIdAsync(Guid Id)
    {
        return await _context.Set<FeatureEntity>()
             .Where(w => w.ProductId == Id).AsNoTracking().ToListAsync();
    }
}
