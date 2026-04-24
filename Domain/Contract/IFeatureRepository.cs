using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IFeatureRepository:IRepository<FeatureEntity>
{
    Task<IList<FeatureEntity>> GetFeaturesByProductIdAsync(Guid Id);
}
