namespace EndPoint_Ui.Areas.Admin.Models.Role;

public sealed record RoleViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PersianName { get; set; }
    public bool IsCustomer { get; set; }
}
