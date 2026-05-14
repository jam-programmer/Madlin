using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class SliderImageRepository : Repository<SliderImageEntity>, ISliderImageRepository
{
    readonly SqlServerContext _context;
    public SliderImageRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<SliderImageEntity>> GetImagesAsync()
    {
        return await _context.Set<SliderImageEntity>().
            Where(w => w.Start <= DateTime.Now &&
        w.End >= DateTime.Now)
            .OrderByDescending(b => b.CreatedAt).ToListAsync();
    }
}
