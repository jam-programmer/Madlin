using Application.Contract;
using Domain.Entities.Product;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    readonly SqlServerContext _context;
    public ProductRepository(SqlServerContext context):base(context)
    {
        _context = context;
    }
}
