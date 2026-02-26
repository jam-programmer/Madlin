namespace Application.Services.Product;

public interface IProductService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InsertProductAsync(ProductDto product,CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateProductAsync(ProductDto product,CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteProductAsync(Guid Id,CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ProductDto> GetProductByIdAsync(Guid Id,CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<ProductDto>> GetProductsAsync(Pagination pagination,CancellationToken cancellationToken=default);
}
