namespace EndPoint_Ui.Models
{
    public sealed record TagViewModel
    {
        public Guid Id { get; set; }
        public string? TitleEn { get; set; }
        public string? Key { get; set; }

        public string? TitleFa { get; set; }
    }
}
