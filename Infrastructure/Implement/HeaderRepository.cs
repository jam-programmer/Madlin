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

public class HeaderRepository : IHeaderRepository
{
    readonly SqlServerContext _context;
    public HeaderRepository(SqlServerContext context)
    {
        _context = context; 
    }
    public async Task<HeaderEntity> GetHeaderAsync(CancellationToken cancellationToken)
    {
       return await _context.Set<HeaderEntity>().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateHeaderAsync(HeaderEntity header, CancellationToken cancellation)
    {
        _context.Set<HeaderEntity>().Update(header);
        await _context.SaveChangesAsync(cancellation);
    }
}
