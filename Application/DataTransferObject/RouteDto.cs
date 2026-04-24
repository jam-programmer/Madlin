using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record RouteDto
{
    public Guid? ParentId { get; set; }
    public Guid? Id { get; set; }
    public string? ControllerName { get; set; }

    public string? UniqueId { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}
