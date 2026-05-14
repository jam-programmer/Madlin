using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Notification;

public interface INotificationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Notification"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertNotificationAsync(NotificationDto Notification, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Notification"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateNotificationAsync(NotificationDto Notification, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="NotificationId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<NotificationDto> GetNotificationByIdAsync(Guid NotificationId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="NotificationId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteNotificationAsync(Guid NotificationId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<NotificationDto>> GetNotificationsAsync(Pagination pagination,
        CancellationToken cancellation = default);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<NotificationDto>>
        GetNotificationsAsync();
}
