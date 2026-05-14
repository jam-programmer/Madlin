using Application.DataTransferObject;
using Application.Services.Notification;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class NotificationComponent:ViewComponent
{
    readonly INotificationService _notificationService;
    public NotificationComponent(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {

      IReadOnlyList<NotificationDto> model =
            await _notificationService.GetNotificationsAsync();
        return View("/Views/Shared/ViewComponent/NotificationComponent.cshtml"
            , model.Adapt<IReadOnlyList<NotificationViewModel>>());

    }
}
