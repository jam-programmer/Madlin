using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class EventRepository : Repository<EventEntity>, IEventRepository
{
    readonly SqlServerContext _context;
    public EventRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteEventImageAsync(Guid Id)
    {
        EventImageEntity? eventImageEntity=
            await _context.Set<EventImageEntity>()
            .FirstOrDefaultAsync(f=>f.Id==Id);
         _context.Remove(eventImageEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<EventImageEntity>> GetImagesByEventIdAsync(Guid eventId)
    {
        return await _context.Set<EventImageEntity>()
            .Where(f=>f.EventId==eventId).ToListAsync();
    }

    public async Task InsertEventImageAsync(EventImageEntity eventImageEntity)
    {
        await _context.AddAsync(eventImageEntity);
        await _context.SaveChangesAsync();
    }
}
