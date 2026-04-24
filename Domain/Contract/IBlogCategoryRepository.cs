using Domain.Entities.Blog;

namespace Domain.Contract;

public interface IBlogCategoryRepository:IRepository<CategoryEntity>
{
    Task<Guid> GetCategoryIdByUrlNameAsync(string urlName);
}
