namespace EndPoint_Ui.Models
{
    public sealed record EventDetailViewModel
    {
        public Guid Id { get; set; }
        public string? Url { get; set; }
        public string? Path { get; set; }
        public string? TitleEn { set; get; }
        public string? TitleFa { set; get; }
        public string? DescriptionEn { set; get; }
        public string? DescriptionFa { set; get; }
        public List<string>? VideoUrls { set; get; }
    }
}
