using Application.Contract;
using Application.DataTransferObject;

namespace Application.Services.Question;

public class QuestionService : IQuestionService
{
    readonly IQuestionRepository _questionRepository;
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public Task DeleteQuestionAsync(Guid QuestionId)
    {
        
        throw new NotImplementedException();
    }

    public Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId)
    {
        throw new NotImplementedException();
    }

    public Task InsertQuestionAsync(QuestionDto Question)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuestionAsync(QuestionDto Question)
    {
        throw new NotImplementedException();
    }
}
