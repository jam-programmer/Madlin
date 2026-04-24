using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Comment;

public interface ICommentService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    Task InsertCommentAsync(CommentDto comment);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    Task UpdateCommentAsync(CommentDto comment);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task DeleteCommentAsync(Guid Id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<CommentDto> GetCommentByIdAsync(Guid Id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <returns></returns>
    Task<PaginatedList<CommentDto>> GetCommentsAsync(Pagination pagination);





    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProductId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ProductCommentDto>> GetCommentsByProductIdAsync(Guid ProductId);
}
