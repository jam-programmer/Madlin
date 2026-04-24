namespace EndPoint_Ui.Areas.Admin.Models.Setting
{
    public sealed record AboutModel
    {
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }
        public string? TextEn { get; set; }
        public string? TextFa { get; set; }
    }
}
