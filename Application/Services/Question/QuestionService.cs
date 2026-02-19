using Application.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Question
{
    public class QuestionService : IQuestionService
    {
       
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
}
