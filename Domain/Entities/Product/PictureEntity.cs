using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class PictureEntity : BaseEntity, IDelete
{
    public string? Path { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    public bool IsDeleted { get; set; }=false;
}
