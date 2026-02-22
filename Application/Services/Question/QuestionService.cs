using Application.Common.CustomException;
using Application.Common.Resource;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities.Identity;
using Domain.Entities.System;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Question;

public class QuestionService : IQuestionService
{
    readonly IQuestionRepository _questionRepository;
    public QuestionService(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task DeleteQuestionAsync(Guid QuestionId)
    {
        QuestionEntity? question = await _questionRepository
    .GetByIdAsync<QuestionEntity>(g => g.Id == QuestionId);

        if (question == null)
            {
                throw new InternalException(Messages.NotFoundOnDb);
            }

            question.IsDeleted = true;

            await _questionRepository.UpdateAsync(question);
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId)
    {
        QuestionEntity? question = await _questionRepository
       .GetByIdAsync<QuestionEntity>(g => g.Id == QuestionId);
        if (question == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return question.Adapt<QuestionDto>();
    }

    public async Task InsertQuestionAsync(QuestionDto Question)
    {
        QuestionEntity question = Question.Adapt<QuestionEntity>();

        await _questionRepository.InsertAsync(question);
    }

    public async Task UpdateQuestionAsync(QuestionDto Question)
    {
        QuestionEntity? question = await _questionRepository
       .GetByIdAsync<QuestionEntity>(g => g.Id == Question.Id);
        if (question == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Question.Adapt(question);
        await _questionRepository.UpdateAsync(question);
    }
}
