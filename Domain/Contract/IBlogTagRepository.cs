using Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IBlogTagRepository:IRepository<BlogTagEntity>
{
    Task<List<Guid>>GetKeyTagsByBlogIdAsync(Guid blogId,CancellationToken cancellation=default);
    Task<List<BlogTagEntity>>GetTagsByBlogIdAsync(Guid blogId,CancellationToken cancellation=default);
    Task DeleteTagsByBlogIdAsync(Guid blogId, CancellationToken cancellation = default);
}

