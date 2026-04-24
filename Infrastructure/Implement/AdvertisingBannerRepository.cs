using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class AdvertisingBannerRepository : Repository<AdvertisingBannerEntity>,
    IAdvertisingBannerRepository
{
    readonly SqlServerContext _context;
    public AdvertisingBannerRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<AdvertisingBannerEntity> GetAdvertisingBannerAsync
        (CancellationToken cancellationToken)
    {
        return await _context.Set<AdvertisingBannerEntity>()
            .FirstOrDefaultAsync();
    }
}
