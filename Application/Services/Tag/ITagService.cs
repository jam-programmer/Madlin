using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Tag;

public interface ITagService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertTagAsync(TagDto tag, CancellationToken cancellation =default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateTagAsync(TagDto tag, CancellationToken cancellation =default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteTagAsync(Guid Id, CancellationToken cancellation =default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<TagDto>> GetTagsAsync(Pagination pagination,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<TagDto> GetTagByIdAsync(Guid Id, CancellationToken cancellation =default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ItemGeneric<Guid, string>>>
           GetTagsForDropDownAsync(string search);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<TagDto>> GetTagsAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<TagDto> GetTagByKeyAsync(string key);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="BlogId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<TagDto>>
        GetTagsByBlogIdAsync(Guid BlogId);
}
