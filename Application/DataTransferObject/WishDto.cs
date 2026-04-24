namespace Application.DataTransferObject;

public sealed record WishDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
