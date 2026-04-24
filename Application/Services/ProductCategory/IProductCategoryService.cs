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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ItemGeneric<Guid, string>>>
        GetCategoriesForDropDownAsync(string search);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IReadOnlyList<FeaturedProductCategoryDto>>
        GetFeaturedProductCategoriesAsync ( CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ProductCategoryItemDto>>
        GetNewestProductCategoriesForSliderAsync(CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="urlName"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryPageDto>GetCategoryByUrlNameAsync(string urlName, 
        CancellationToken cancellation = default);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<ProductCategoryItemDto>> GetProductCategoriesForFilterAsync();
}
