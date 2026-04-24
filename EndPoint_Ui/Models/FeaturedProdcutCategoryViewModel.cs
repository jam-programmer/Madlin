namespace EndPoint_Ui.Models
{
    public sealed record FeaturedProductCategoryViewModel
    {
        public string? TitleEn { get; set; }
        public string? TitleFa { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionFa { get; set; }
        public string? MainImagePath { get; set; }
        public string? UrlName { get; set; }
    }
}
