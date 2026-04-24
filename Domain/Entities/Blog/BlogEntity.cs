using Domain.Entities.Identity;

namespace Domain.Entities.Blog;

public class BlogEntity : BaseEntity, IDelete
{
    public string? UrlName { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? ImagePath { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public string? ShortDescriptionEn { get; set; }
    public string? ShortDescriptionFa { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
    public CategoryEntity? Category { get; set; }
    public Guid CategoryId { get; set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }   

    public ICollection<BlogTagEntity>? BlogTags { get; set; }    
}
