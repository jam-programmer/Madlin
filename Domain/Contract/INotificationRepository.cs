using System;
using Domain.Entities.System;

namespace Domain.Contract;

public interface INotificationRepository : IRepository<NotificationEntity>
{
    Task<IList<NotificationEntity>> GetNotificationsAsync();
}
