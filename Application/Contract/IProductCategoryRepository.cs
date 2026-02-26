using Domain.Entities.Product;

namespace Application.Contract;

public interface IProductCategoryRepository : IRepository<CategoryEntity>
{
}
