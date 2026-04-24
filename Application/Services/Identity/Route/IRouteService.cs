namespace Application.Services.Identity.Route;

public interface IRouteService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<List<RouteDto>> GetRoutesAsync(CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IList<Guid>>GetRoutesByRoleIdAsync(Guid roleId,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleRoute"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertRoleRouteAsync(RoleRouteDto roleRoute,CancellationToken cancellation=default);
}
