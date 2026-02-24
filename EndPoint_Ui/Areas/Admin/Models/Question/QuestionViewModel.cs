namespace EndPoint_Ui.Areas.Admin.Models.Question;

public sealed record QuestionViewModel
{
    public Guid Id { get; set; }
    public string? TitleFa { get; set; }
    public string? TitleEn { get; set; }
}
