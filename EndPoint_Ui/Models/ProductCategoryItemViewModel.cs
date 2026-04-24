namespace EndPoint_Ui.Models
{
    public sealed record ProductCategoryItemViewModel
    {
        public Guid Id { get; set; }
        public string? UrlName { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleFa { get; set; }
        public string? IconImagePath { get; set; }
        public int Count { get; set; }
    }
}
