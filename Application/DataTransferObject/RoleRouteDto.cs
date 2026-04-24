using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record RoleRouteDto
{
    public Guid RoleId { get; set; }
    public List<Guid> Routes { get; set; }
}
