namespace EndPoint_Ui.Areas.Admin.Models.Setting;

public sealed record AdvertisingBannerModel
{
    public string? ImageOnePath { get; set; }
    public string? ImageTwoPath { get; set; }
    public string? ImageThreePath { get; set; }
    public string? ImageFourPath { get; set; }
    public string? ImageFivePath { get; set; }
    public IFormFile? ImageOneFile { get; set; }
    public IFormFile? ImageTwoFile { get; set; }
    public IFormFile? ImageThreeFile { get; set; }
    public IFormFile? ImageFourFile { get; set; }
    public IFormFile? ImageFiveFile { get; set; }
}
