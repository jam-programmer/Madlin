namespace EndPoint_Ui.Areas.Admin.Models.Notification;

public sealed record NotificationViewModel
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public string? Path { get; set; }
    public string? TitleFa { get; set; }
    public string? Start { get; set; }
    public string? End { get; set; }
}
