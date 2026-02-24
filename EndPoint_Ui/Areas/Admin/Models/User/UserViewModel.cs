namespace EndPoint_Ui.Areas.Admin.Models.User;

public sealed record UserViewModel
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; }
}
