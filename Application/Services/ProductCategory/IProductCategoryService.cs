using Application.Common;
using Application.DataTransferObject;

namespace Application.Services.ProductCategory;

public interface IProductCategoryService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productCategory"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertProductCategoryAsync(ProductCategoryDto productCategory, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="productCategory"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateProductCategoryAsync(ProductCategoryDto productCategory, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProductCategoryId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteProductCategoryAsync(Guid ProductCategoryId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProductCategoryId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<ProductCategoryDto> GetProductCategoryByIdAsync
        (Guid ProductCategoryId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<ProductCategoryDto>> GetProductCategoriesAsync
        (Pagination pagination, CancellationToken cancellation = default);
}
