using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface ICommentRepository:IRepository<CommentEntity>
{
    Task<IList<CommentEntity>> GetCommentsByProductIdAsync(Guid id);
}
