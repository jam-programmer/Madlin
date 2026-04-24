using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BlogCategory;

public interface IBlogCategoryService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="category"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertBlogCategoryAsync(BlogCategoryDto category,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="category"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateBlogCategoryAsync(BlogCategoryDto category,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteBlogCategoryAsync(Guid Id,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<BlogCategoryDto> GetBlogCategoryByIdAsync(Guid Id, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<BlogCategoryDto>> GetBlogCategoriesAsync(Pagination pagination,CancellationToken cancellation=default);
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
    /// <returns></returns>
    Task<IReadOnlyList<BlogCategoryDto>> GetBlogCategoriesAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="urlName"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<BlogCategoryDto> GetBlogCategoryByUrlNameAsync(string urlName,CancellationToken cancellation=default);
}
