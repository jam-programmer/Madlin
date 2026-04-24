using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class ResponseRepository : Repository<ResponseEntity>, IResponseRepository
{
    readonly SqlServerContext _context;

    public ResponseRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
}
