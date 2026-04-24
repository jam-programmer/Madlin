using Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface ITagRepository:IRepository<TagEntity>
{
    Task<IList<Guid>> GetBlogIdsByTagAsync(string key);
    Task<IList<TagEntity>> GetTagsByBlogIdAsync(Guid blogId);
}
