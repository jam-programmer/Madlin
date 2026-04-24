using Domain.Entities.Product;

namespace Domain.Contract;

public interface IProductCategoryRepository : IRepository<CategoryEntity>
{
    Task<List<CategoryEntity>> GetFeaturedProductCategoriesAsync(CancellationToken cancellation);
    Task<List<CategoryEntity>> GetNewestProductCategoriesAsync(CancellationToken cancellation);
    Task<Guid> GetCategoryIdByUrlNameAsync(string urlName,CancellationToken cancellation);
    
}
