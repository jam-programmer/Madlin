namespace Domain.Entities.Product;

public class CommentEntity : BaseEntity, IDelete
{
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? UserPublicName { get; set; }
    public string? UserPhoneNumber { get; set; }
    public bool IsActive { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity? Product { get; set; }
    public ResponseEntity Response { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}
