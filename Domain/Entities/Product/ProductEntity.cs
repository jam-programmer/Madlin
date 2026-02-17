namespace Domain.Entities.Product;

public class ProductEntity : BaseEntity
{
    
    public string TitleEn { get; set; }
    public string TitleFa { get; set; }
    public string MainImagePath { get; set; }

    public string HoverImagePath { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string ShortDescriptionEn { get; set; }
    public string ShortDescriptionFa { get; set; }
    public string FullDescriptionEn { get; set; }
    public string FullDescriptionFa { get; set; }

    public int Quantity { get; set; }

    
    public string ProductCode { get; set; }

    public int Rating { get; set; }

    #region Relation
    public CategoryEntity Category { get; set; }
    public Guid CategoryId { get; set; }
    #endregion
    public bool IsDeleted { get; set; } = false;


}
