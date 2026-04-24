namespace EndPoint_Ui.Models
{
    public sealed record PageItemViewModel
    {
        public Guid Id { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleFa { get; set; }
        public string? Url { get; set; }
    }
}
