namespace EndPoint_Ui.Models;

public sealed record ProductCommentViewModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public string? ResponseText { get; set; }
    public string? UserPublicName { get; set; }
    public string? CreatedDate { get; set; }
    public string? ResponseCreatedDate { get; set; }
}
