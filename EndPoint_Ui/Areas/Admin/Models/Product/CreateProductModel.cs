using System.ComponentModel.DataAnnotations;

namespace EndPoint_Ui.Areas.Admin.Models.Product;

public record CreateProductModel
{
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "عنوان انگلیسی الزامی است")]
    public string? TitleEn { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "عنوان فارسی الزامی است")]
    public string? TitleFa { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "تصویر شاخص الزامی است")]
    public IFormFile? MainImageFile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "تصویر هاور الزامی است")]
    public IFormFile? HoverImageFile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? UrlName { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "قیمت الزامی است")]

    public ulong Price { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public ulong? DiscountPrice { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "توضیح کوتاه انگلیسی الزامی است")]

    public string? ShortDescriptionEn { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "توضیح کوتاه فارسی الزامی است")]

    public string? ShortDescriptionFa { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "توضیح انگلیسی الزامی است")]

    public string? FullDescriptionEn { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "توضیح فارسی الزامی است")]

    public string? FullDescriptionFa { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "تعداد موجودی الزامی است")]

    public int Quantity { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "شناسه محصول الزامی است")]

    public string? ProductCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Rating { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "دسته بندی الزامی است")]
    public Guid CategoryId { get; set; }
}
