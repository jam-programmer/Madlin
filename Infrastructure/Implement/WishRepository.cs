using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class WishRepository : Repository<WishEntity>, IWishRepository
{
    readonly SqlServerContext _context;
    public WishRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<WishEntity>> GetWishListByUserIdAsync(Guid userId)
    {
        return await _context.Set<WishEntity>()
            .Include(i=>i.Product).AsNoTracking()
            .ToListAsync();
    }
}
