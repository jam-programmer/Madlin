namespace EndPoint_Ui.Areas.Admin.Models.Image;

public sealed record ImageViewModel
{
    public Guid Id { get; set; }
    public string? FilePath { set; get; }
}
