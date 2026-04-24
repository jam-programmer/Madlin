namespace EndPoint_Ui.Areas.Admin.Models.Tag;

public sealed record TagViewModel
{
    public Guid Id { get; set; }
    public string? TitleEn { get; set; }
    public string? TitleFa { get; set; }
}
