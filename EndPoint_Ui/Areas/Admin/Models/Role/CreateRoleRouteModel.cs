namespace EndPoint_Ui.Areas.Admin.Models.Role;

public sealed record CreateRoleRouteModel
{
    public Guid RoleId { get; set; }
    public List<Guid> Routes { get; set; }
}
