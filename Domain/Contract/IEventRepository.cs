using Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IEventRepository:IRepository<EventEntity>
{
    Task<IList<EventImageEntity>> GetImagesByEventIdAsync(Guid eventId);
    Task InsertEventImageAsync(EventImageEntity eventImageEntity);
    Task DeleteEventImageAsync(Guid Id);
}
