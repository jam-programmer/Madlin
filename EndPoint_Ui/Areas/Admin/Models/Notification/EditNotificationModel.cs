namespace EndPoint_Ui.Areas.Admin.Models.Notification;

public sealed record EditNotificationModel: CreateNotificationModel
{

    public Guid Id { get; set; }
    public string? Path { get; set; }

}
