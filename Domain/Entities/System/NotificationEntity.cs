namespace Domain.Entities.System;

public class NotificationEntity : BaseEntity, IDelete, ICreate
{
    public int Size {  get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public string? Path { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
    public bool IsActive { get; set; }  
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
