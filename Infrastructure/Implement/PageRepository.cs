using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class PageRepository : Repository<PageEntity>,
    IPageRepository
{
    readonly SqlServerContext _context;
    public PageRepository(SqlServerContext context) : base(context)
    {
        _context = context; 
    }
    public async Task<IReadOnlyList<PageEntity>> GetPagesByShowPositionAsync(int showPosition)
    {
        return await _context.Set<PageEntity>()
            .Where(w=>w.Show == showPosition)   .ToListAsync(); 
    }

    public async Task<PageEntity> GetPageByUrlAsync(string url)
    {
        return await _context.Set<PageEntity>()
          .FirstOrDefaultAsync(f=>f.Url==url);
    }
}
