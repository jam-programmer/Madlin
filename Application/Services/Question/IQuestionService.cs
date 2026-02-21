using Application.DataTransferObject;

namespace Application.Services.Question;

public interface IQuestionService
{
    Task InsertQuestionAsync(QuestionDto Question);
    Task UpdateQuestionAsync(QuestionDto Question);
    Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId);
    Task DeleteQuestionAsync(Guid QuestionId);
}
