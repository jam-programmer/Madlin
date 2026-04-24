using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Feature;

public interface IFeatureService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<FeatureDto> GetFeatureByIdAsync(Guid Id ,CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PaginatedList<FeatureDto>> GetFeaturesAsync(PaginationWithParent pagination, CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertFeatureAsync(FeatureDto feature,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateFeatureAsync(FeatureDto feature,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteFeatureAsync(Guid Id, CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductIdAsync(Guid Id);
}
