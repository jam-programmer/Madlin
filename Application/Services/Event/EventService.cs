
using Application.Common.Extension;
using Domain.Entities.System;
using Mapster;

namespace Application.Services.Event;

public class EventService : IEventService
{
    readonly IEventRepository _repository;
    public EventService(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task DeleteEventAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        EventEntity entity = await _repository.GetByIdAsync(g => g.Id == Id);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        entity.IsDeleted = true;
        await _repository.UpdateAsync(entity, cancellationToken);
    }

    public async Task DeleteEventImageAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        await _repository.DeleteEventImageAsync(Id);
    }

    public async Task<EventDto> GetEventByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        EventEntity entity = await _repository.GetByIdAsync(g => g.Id == Id);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return entity.Adapt<EventDto>();
    }

    public async Task<EventDto> GetEventByUrlAsync(string Url, CancellationToken cancellationToken = default)
    {
        EventEntity entity = await _repository.GetByIdAsync(g => g.Url == Url);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return entity.Adapt<EventDto>();
    }

    public async Task<IReadOnlyList<EventImageDto>> GetEventImagesByEventIdAsync(Guid EventId)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<EventDto>> GetEventsAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        IQueryable<EventEntity> query = _repository.GetByQuery();
        TypeAdapterConfig config = new();
        config.NewConfig<EventEntity, EventDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.Path, s => s.Path)
            .Compile();

        PaginatedList<EventDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();
        query = query.OrderByDescending(d => d.CreatedAt);
        model = await query.MappingedAsync<EventEntity, EventDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task<IReadOnlyList<EventImageDto>> GetImagesByEventIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        IList<EventImageEntity> images = await _repository.GetImagesByEventIdAsync(Id);
        return images.Adapt<IReadOnlyList<EventImageDto>>();
    }

    public async Task InsertEventAsync(EventDto Event, CancellationToken cancellationToken = default)
    {
        Random random = new();
        string baseUrl = Application.Common.Extension.Common.GenerateRandomString();
        string url = baseUrl;
        while (await _repository.ExistAsync(e => e.Url == url, cancellationToken))
        {
            url = $"{baseUrl}{random.Next(1, 100)}";
        }
        EventEntity entity = Event.Adapt<EventEntity>();
        entity.Path = Event.File!.UploadImage("Event");
        entity.Url = url;
        await _repository.InsertAsync(entity, cancellationToken);
    }

    public async Task InsertEventImageAsync(EventImageDto eventImage, CancellationToken cancellationToken = default)
    {
     

        EventImageEntity entity = new();
        entity.EventId = eventImage.EventId;
        entity.Path = eventImage.File.UploadImage("Event");
        await _repository.InsertEventImageAsync(entity);
    }

    public async Task UpdateEventAsync(EventDto Event, CancellationToken cancellationToken = default)
    {

        bool isUrlDuplicate = await _repository.ExistAsync(
         e => e.Url == Event.Url && e.Id != Event.Id, cancellationToken);
        if (isUrlDuplicate)
        {
            Random random = new();
            string baseUrl = Application.Common.Extension.Common.GenerateRandomString();
            string url = baseUrl;
            while (await _repository.ExistAsync(e => e.Url == url, cancellationToken))
            {
                url = $"{baseUrl}{random.Next(1, 100)}";
            }
            Event.Url = url;
        }

        EventEntity entity = await _repository.GetByIdAsync(g => g.Id == Event.Id);
        if (entity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Event.Adapt(entity);
        if (Event.File != null)
        {
            entity.Path = Event.File!.UploadImage("Event");

            Event.Path!.RemoveImage("Event");
        }
        await _repository.UpdateAsync(entity, cancellationToken);
    }
}
