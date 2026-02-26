using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Resource;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities.Identity;
using Domain.Entities.Product;
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

    public async Task DeleteQuestionAsync(Guid QuestionId, CancellationToken cancellation = default)
    {
        QuestionEntity? question = await _questionRepository
    .GetByIdAsync(g => g.Id == QuestionId);

        if (question == null)
            {
                throw new InternalException(Messages.NotFoundOnDb);
            }

            question.IsDeleted = true;

            await _questionRepository.UpdateAsync(question,cancellation);
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId, CancellationToken cancellation = default)
    {
        QuestionEntity? question = await _questionRepository
       .GetByIdAsync(g => g.Id == QuestionId);
        if (question == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return question.Adapt<QuestionDto>();
    }

    public async Task<PaginatedList<QuestionDto>> GetQuestionsAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        IQueryable<QuestionEntity> query = _questionRepository.GetByQuery();
        TypeAdapterConfig config = new();
        config.NewConfig<QuestionEntity, QuestionDto>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.Id, s => s.Id)
            .Compile();
        PaginatedList<QuestionDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||

                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<QuestionEntity, QuestionDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task InsertQuestionAsync(QuestionDto Question, CancellationToken cancellation = default)
    {
        QuestionEntity question = Question.Adapt<QuestionEntity>();

        await _questionRepository.InsertAsync(question,cancellation);
    }

    public async Task UpdateQuestionAsync(QuestionDto Question, CancellationToken cancellation = default)
    {
        QuestionEntity? question = await _questionRepository
       .GetByIdAsync(g => g.Id == Question.Id);
        if (question == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Question.Adapt(question);
        await _questionRepository.UpdateAsync(question, cancellation);
    }
}
