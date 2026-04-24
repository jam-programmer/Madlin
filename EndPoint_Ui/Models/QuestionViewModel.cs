namespace EndPoint_Ui.Models
{
    public sealed record QuestionViewModel
    {
        public Guid Id { get; set; }
        public string? TitleFa { get; set; }
        public string? DescriptionFa { get; set; }
        public string? TitleEn { get; set; }
        public string? DescriptionEn { get; set; }
    }
}
