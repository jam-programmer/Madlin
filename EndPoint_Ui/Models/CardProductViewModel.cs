namespace EndPoint_Ui.Models
{
    public sealed record CardProductViewModel
    {
        public string? TitleEn { get; set; }
        public string? TitleFa { get; set; }
        public string? MainImagePath { get; set; }
        public string? HoverImagePath { get; set; }
        public string? UrlName { get; set; }
        public ulong Price { get; set; }
        public Guid Id { get; set; }
        public ulong? DiscountPrice { get; set; }
    }
}
