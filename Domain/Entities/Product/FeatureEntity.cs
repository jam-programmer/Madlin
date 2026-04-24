using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product;

public class FeatureEntity : BaseEntity, IDelete
{
    public string? TitleFa { get; set; }
    public string? ValueFa { get; set; }
    public string? TitleEn { get; set; }
    public string? ValueEn { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    public bool IsDeleted { get; set; } = false;
}
