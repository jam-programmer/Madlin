using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Event;

public interface IEventService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Event"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InsertEventAsync(EventDto Event, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Event"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateEventAsync(EventDto Event, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteEventAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<EventDto> GetEventByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Url"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<EventDto> GetEventByUrlAsync(string Url, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<EventDto>> GetEventsAsync(Pagination pagination,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>

    Task<IReadOnlyList<EventImageDto>>
        GetImagesByEventIdAsync(Guid Id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventImage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InsertEventImageAsync(EventImageDto eventImage, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteEventImageAsync(Guid Id, CancellationToken cancellationToken = default);

}
