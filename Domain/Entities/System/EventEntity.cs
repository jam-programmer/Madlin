namespace Domain.Entities.System;

public class EventEntity : BaseEntity,IDelete
{
    public string? Url { get; set; }
    public string? Path { get; set; }
    public string? TitleEn { set; get; }
    public string? TitleFa { set; get; }
    public string? DescriptionEn { set; get; }
    public string? DescriptionFa { set; get; }
    public ICollection<EventImageEntity> EventImages { set; get; }
    public List<string> VideoUrls { set; get; }
    public bool IsDeleted { get ; set ; }=false;
    public DateTime? CreatedAt { get; set; }=DateTime.Now;
}
