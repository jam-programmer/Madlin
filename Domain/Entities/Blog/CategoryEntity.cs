namespace Domain.Entities.Blog;

public class CategoryEntity : BaseEntity, IDelete
{
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? UrlName { get; set; }
    public bool IsDeleted { get; set; }=false;
    public ICollection<BlogEntity>? Blogs { get; set; }
}
