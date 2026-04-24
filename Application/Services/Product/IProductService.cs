namespace Application.Services.Product;

public interface IProductService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InsertProductAsync(ProductDto product, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateProductAsync(ProductDto product, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteProductAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ProductDto> GetProductByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<ProductDto>> GetProductsAsync(Pagination pagination,
        CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ProductItemDto>>
        GetNewestProductsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ProductItemDto>>
        GetProductsForSliderAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<ProductItemDto>>
        GetProductsByCategoryAsync(PaginationWithKey pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="UrlName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<ProductDetailDto> GetProductDetailByUrlName(string UrlName, 
        CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ProductItemDto>> GetProductsFromWishListAsync(Guid UserId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginatedList<ProductItemDto>> GetProductsForProductListPageAsync(Pagination pagination);
}
