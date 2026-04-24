namespace EndPoint_Ui.Areas.Admin.Models.Page
{
    public class PageViewModel
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? TitleFa { get; set; }
        public ShowType Show { get; set; }
    }
}
