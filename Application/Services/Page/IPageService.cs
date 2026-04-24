using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Page;

public interface IPageService
{  /// <summary>
   /// 
   /// </summary>
   /// <param name="Page"></param>
   /// <param name="cancellationToken"></param>
   /// <returns></returns>
    Task InsertPageAsync(PageDto Page, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Page"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdatePageAsync(PageDto Page, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeletePageAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PageDto> GetPageByIdAsync(Guid Id, CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<PageDto>> GetPagesAsync(Pagination pagination,
        CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<PageItemDto>>
        GetItemPagesByPositionAsync(int show);


    Task<PageDto> GetPageByUrlAsync(string Url);

}
