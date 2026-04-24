using Domain.Entities.Product;

namespace Domain.Contract;

public interface IProductRepository : IRepository<ProductEntity>
{
    Task<IList<ProductEntity>> GetNewestProductsAsync(CancellationToken cancellation = default);
    Task<IList<ProductEntity>> GetProductsForSliderAsync(CancellationToken cancellation = default);


}
