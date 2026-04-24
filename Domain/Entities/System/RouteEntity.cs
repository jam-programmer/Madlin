using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class RouteEntity:BaseEntity
{
    public Guid? ParentId { get; set; }
    public string? UniqueId { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? ControllerName { get; set; }
    public ICollection<RoleRouteEntity> RoleRoutes { get; set; }

}
