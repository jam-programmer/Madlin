
using Application.Common.Extension;
using Domain.Contract;
using Domain.Entities.System;
using Mapster;

namespace Application.Services.Notification;

public class NotificationService : INotificationService
{
    readonly INotificationRepository _notificationRepository;
    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }
    public async Task DeleteNotificationAsync(Guid NotificationId, CancellationToken cancellation = default)
    {
        NotificationEntity entity = await _notificationRepository
            .GetByIdAsync(g => g.Id == NotificationId);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        entity.IsDeleted = true;
        await _notificationRepository.UpdateAsync(entity, cancellation);
    }

    public async Task<NotificationDto> GetNotificationByIdAsync(Guid NotificationId, CancellationToken cancellation = default)
    {
        NotificationEntity entity = await _notificationRepository
             .GetByIdAsync(g => g.Id == NotificationId);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return entity.Adapt<NotificationDto>();
    }

    public async Task<PaginatedList<NotificationDto>> GetNotificationsAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<NotificationEntity, NotificationDto>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.IsActive, s => s.IsActive)
            .Map(d => d.Path, s => s.Path)
            .Map(d => d.Start, s => s.Start)
            .Map(d => d.End, s => s.End)
                        .Compile();


        IQueryable<NotificationEntity> query = _notificationRepository.GetByQuery();
        PaginatedList<NotificationDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||

                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<NotificationEntity, NotificationDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task<IReadOnlyList<NotificationDto>> GetNotificationsAsync()
    {
        IList<NotificationEntity> notifications=await _notificationRepository.GetNotificationsAsync();
        return notifications.Adapt<IReadOnlyList<NotificationDto>>();
    }

    public async Task InsertNotificationAsync(NotificationDto Notification, CancellationToken cancellation = default)
    {
        NotificationEntity entity = Notification.Adapt<NotificationEntity>();
       
            entity.Path = Notification.File.UploadImage("Notification");
        
        await _notificationRepository.InsertAsync(entity, cancellation);
    }

    public async Task UpdateNotificationAsync(NotificationDto Notification, CancellationToken cancellation = default)
    {
        NotificationEntity entity = await _notificationRepository
            .GetByIdAsync(g => g.Id == Notification.Id);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Notification.Adapt(entity);
            entity.Path = Notification.File.UploadImage("Notification");
        if (Notification.File is not null)
        {
            Notification!.Path!.RemoveImage("Notification");
        }
        await _notificationRepository .UpdateAsync(entity, cancellation);
    }
}
