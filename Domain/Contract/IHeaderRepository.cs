using Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IHeaderRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<HeaderEntity> GetHeaderAsync(CancellationToken cancellationToken);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="header"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateHeaderAsync(HeaderEntity header,CancellationToken cancellation);
}
