using Domain.Contract;
using Domain.Entities.System;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class MessageRepository : Repository<MessageEntity>, IMessageRepository
{
    readonly SqlServerContext _context;
    public MessageRepository(SqlServerContext context) : base(context)
    {
        _context = context; 
    }
}
