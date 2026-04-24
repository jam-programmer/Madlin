using Application.DataTransferObject;

namespace Application.Services.Question;

public interface IQuestionService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Question"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertQuestionAsync(QuestionDto Question,CancellationToken cancellation=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Question"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateQuestionAsync(QuestionDto Question, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="QuestionId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="QuestionId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteQuestionAsync(Guid QuestionId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<QuestionDto>> GetQuestionsAsync(Pagination pagination,
        CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<QuestionDto>> GetQuestionsAsync();
}
