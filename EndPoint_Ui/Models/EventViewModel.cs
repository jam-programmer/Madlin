namespace EndPoint_Ui.Models
{
    public sealed record EventViewModel
    {
        public Guid Id { get; set; }
        public string? Path { get; set; }
        public string? Url { get; set; }
        public string? TitleEn { set; get; }
        public string? TitleFa { set; get; }
    }
}
