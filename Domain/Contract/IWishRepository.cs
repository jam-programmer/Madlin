using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IWishRepository:IRepository<WishEntity>
{
    Task<IList<WishEntity>> GetWishListByUserIdAsync(Guid userId);
}
