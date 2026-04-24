namespace EndPoint_Ui.Areas.Admin.Models.Page
{
    public record CreatePageModel
    {
        public string? TitleFa { get; set; }
        public string? TitleEn { get; set; }
        public string? TextEn { get; set; }
        public string? TextFa { get; set; }
        public int Show { get; set; }
    }
}
