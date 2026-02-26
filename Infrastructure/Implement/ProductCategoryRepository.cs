using Application.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;

namespace Infrastructure.Implement;

public class ProductCategoryRepository : Repository<CategoryEntity>,
    IProductCategoryRepository
{
    readonly SqlServerContext _context;
    public ProductCategoryRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
}
