using Domain.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;

namespace Infrastructure.Implement;

public class PictureRepository:Repository<PictureEntity>, IPictureRepository
{
    readonly SqlServerContext _context;
    public PictureRepository(SqlServerContext context):base(context)    
    {
        _context = context;
    }
}
