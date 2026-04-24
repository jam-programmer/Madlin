using Domain.Contract;
using Domain.Entities.Identity;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class RoleRouteRepository :
   Repository<RoleRouteEntity>,
    IRoleRouteRepository
{
    readonly SqlServerContext _context;
    public RoleRouteRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<RoleRouteEntity>> GetRoutesByRoleIdAsync(Guid RoleId,CancellationToken cancellation=default)
    {
            return await _context.Set<RoleRouteEntity>()
            .Where(w=>w.RoleId == RoleId).AsNoTracking().ToListAsync();
    }
    public async Task DeleteRoleRoutesAsync(Guid RoleId, CancellationToken cancellation)
    {
       await _context.Set<RoleRouteEntity>()
            .Where(w => w.RoleId == RoleId).ExecuteDeleteAsync();
    }
}
