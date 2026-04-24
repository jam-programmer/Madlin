using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class RouteRepository : Repository<RouteEntity>, IRouteRepository
{
    readonly SqlServerContext _context;
    public RouteRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<RouteEntity>> GetRoutesAsync(CancellationToken cancellation = default)
    {
        return await _context.Set<RouteEntity>().AsNoTracking().ToListAsync(cancellation);  
    }
}
