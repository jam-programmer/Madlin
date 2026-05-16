using Domain.Entities.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IGeneralRepository:IRepository<GeneralEntity>
{
    Task<GeneralEntity> GetGeneralAsync
        (CancellationToken cancellationToken=default);
      Task<SeoEntity> GetSeoAsync
        (CancellationToken cancellationToken=default);

    Task UpdateSeoAsync(SeoEntity seo);
    Task<(string toke, string number)> GetSmsInfoAsync();

}
