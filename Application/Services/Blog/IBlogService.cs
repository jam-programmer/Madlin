namespace Application.Services.Blog;

public interface IBlogService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="blog"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertBlogAsync(BlogDto blog, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="blog"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateBlogAsync(BlogDto blog, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteBlogAsync(Guid Id, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<BlogDto> GetBlogAsync(Guid Id, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<BlogDto>> GetBlogsAsync(Pagination pagination, CancellationToken cancellation = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ItemGeneric<Guid,string>>>
        GetTagsByBlogIdAsync(Guid Id, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IReadOnlyList<BlogItemDto>> GetNewestBlogsAsync(int take,CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginatedList<BlogItemDto>> GetBlogsForBlogListPageAsync(Pagination pagination);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="categoryUrlName"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginatedList<BlogItemDto>> GetBlogsByCategoryUrlNamAsync( PaginationWithKey pagination);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginatedList<BlogItemDto>> GetBlogsByTagAsync( PaginationWithKey pagination);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="urlName"></param>
    /// <returns></returns>
    Task<BlogDetailDto> GetBlogByUrlNameAsync(string urlName);




}
