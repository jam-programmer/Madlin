using Domain.Entities.Identity;
using Domain.Entities.System;
using Mapster;

namespace Application.Services.Identity.Route;

public class RouteService : IRouteService
{
    readonly IRoleRouteRepository _roleRouteRepository;
    readonly IRouteRepository _routeRepository;
    public RouteService(IRoleRouteRepository roleRouteRepository,
        IRouteRepository routeRepository)
    {
        _roleRouteRepository = roleRouteRepository;
        _routeRepository = routeRepository;
    }

    public async Task<List<RouteDto>>
        GetRoutesAsync(CancellationToken cancellation = default)
    {
        IList<RouteEntity> routeEntities = await _routeRepository.GetRoutesAsync(cancellation);
        return routeEntities.Adapt<List<RouteDto>>();
    }

    public async Task<IList<Guid>> GetRoutesByRoleIdAsync(Guid roleId,
        CancellationToken cancellation = default)
    {
        IList<RoleRouteEntity> roleRouteEntities = await _roleRouteRepository.
            GetRoutesByRoleIdAsync(roleId, cancellation);
        return roleRouteEntities.Select(s => s.RouteId).ToList();
    }

    public async Task InsertRoleRouteAsync(RoleRouteDto roleRoute, CancellationToken cancellation = default)
    {
        List<RoleRouteEntity> roleRoutes = [];
        await _roleRouteRepository.DeleteRoleRoutesAsync(roleRoute.RoleId, cancellation);
        if (roleRoute.Routes != null && roleRoute.Routes.Any())
        {
            foreach (Guid route in roleRoute.Routes)
            {
                RoleRouteEntity roleRouteEntity = new()
                {
                    RoleId = roleRoute.RoleId,
                    RouteId = route
                };
                roleRoutes.Add(roleRouteEntity);
            }
            await _roleRouteRepository.InsertAsync(roleRoutes, cancellation);
        }

    }
}
