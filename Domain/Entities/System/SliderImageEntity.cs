namespace Domain.Entities.System;

public class SliderImageEntity:BaseEntity,IDelete, ICreate
{
    public string? Title { get; set; }
    public string? Path { get; set; }
    public string? Link { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public bool IsDeleted { get; set ; }=false;
    public DateTime CreatedAt { get; set; }=DateTime.Now;
}
