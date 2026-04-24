using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class CommentRepository : Repository<CommentEntity>, ICommentRepository
{
    readonly SqlServerContext _context; 
    public CommentRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IList<CommentEntity>> GetCommentsByProductIdAsync(Guid id)
    {
        return await _context.Set<CommentEntity>()
            .Include(i=>i.Response).Where(i=>i.ProductId == id && i.IsActive==true)
            .AsNoTracking().ToListAsync ();
    }
}
