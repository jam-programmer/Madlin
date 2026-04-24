using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IRoleRouteRepository:IRepository<RoleRouteEntity>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="RoleId"></param>
    /// <returns></returns>
    Task<IList<RoleRouteEntity>> GetRoutesByRoleIdAsync(Guid RoleId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="RoleId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteRoleRoutesAsync(Guid RoleId,CancellationToken cancellation);
}
