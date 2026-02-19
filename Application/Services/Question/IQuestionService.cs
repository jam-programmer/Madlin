using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Question
{
    public interface IQuestionService
    {
        Task InsertQuestionAsync(QuestionDto Question);
        Task UpdateQuestionAsync(QuestionDto Question);
        Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId);
        Task DeleteQuestionAsync(Guid QuestionId);
    }
}
