namespace Domain.Entities.System;

public class MessageEntity : BaseEntity, IDelete
{
    public DateTime CreatedAt { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool IsDeleted { get; set; } = false;
}
