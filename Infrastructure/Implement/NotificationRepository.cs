using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implement;

public class NotificationRepository
    : Repository<NotificationEntity>,
    INotificationRepository
{
    readonly SqlServerContext _context;
    public NotificationRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IList<NotificationEntity>> GetNotificationsAsync()
    {
        return await _context.Set<NotificationEntity>()
            .Where(w=>w.IsActive == true &&
            w.Start<=DateTime.Now &&
            w.End >=DateTime.Now).
            OrderByDescending(o=>o.CreatedAt).ToListAsync();
    }
}
