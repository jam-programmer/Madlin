using Domain.Entities.Blog;

namespace Domain.Contract;

public interface IBlogRepository : IRepository<BlogEntity>
{
    Task<BlogEntity> GetByIdAndJoinAsync(Guid id, CancellationToken cancellation = default);
    Task<IList<BlogEntity>> GetNewestBlogsAsync(int take,CancellationToken cancellation = default);
}
