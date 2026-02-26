namespace EndPoint_Ui.Areas.Admin.Models.Question;

public sealed record EditQuestionModel:CreateQuestionModel
{
    public Guid Id { get; set; }
}
