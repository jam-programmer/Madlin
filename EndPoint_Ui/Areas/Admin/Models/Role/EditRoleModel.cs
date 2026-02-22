using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Role;

public sealed record EditRoleModel: CreateRoleModel
{

    public Guid Id { get; set; }
  
}
