using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class WishEntity:BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public UserEntity? User { get; set; }
    public ProductEntity? Product { get; set; }
}
