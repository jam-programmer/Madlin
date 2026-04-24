using Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity;

public class RoleRouteEntity:BaseEntity
{
    public Guid RouteId { get; set; }
    public Guid RoleId { get; set; }
    public RoleEntity RoleEntity { get; set; }
    public RouteEntity RouteEntity { get; set; }
}
