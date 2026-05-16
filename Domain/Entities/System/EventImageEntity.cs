using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class EventImageEntity:BaseEntity 
{
    public string? Path { get; set; }
    public EventEntity? Event {  get; set; }
    public Guid EventId { get; set; }
}
