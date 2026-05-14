namespace EndPoint_Ui.Models;

public sealed record NotificationViewModel
{
    public Guid Id { get; set; }
    public int Size { get; set; }
    public string? Path { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
    public string? DescriptionEn { get; set; }
    public string? DescriptionFa { get; set; }
}
