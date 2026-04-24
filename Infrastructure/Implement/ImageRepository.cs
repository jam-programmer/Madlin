using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class ImageRepository :
    Repository<ImageEntity>, IImageRepository
{
    readonly SqlServerContext _context;
    public ImageRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<ImageEntity>> GetImagesAsync(CancellationToken cancellation)
    {
        return await _context.Set<ImageEntity>().ToListAsync(cancellation);
    }
}
