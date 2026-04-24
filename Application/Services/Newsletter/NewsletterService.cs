
using Application.Common.Extension;
using Domain.Contract;
using Domain.Entities.Product;
using Domain.Entities.System;
using Mapster;

namespace Application.Services.Newsletter;

public class NewsletterService : INewsletterService
{
    readonly INewsletterRepository _newsletterRepository;
    public NewsletterService(INewsletterRepository newsletterRepository)
    {
        _newsletterRepository = newsletterRepository;
    }

    public async Task DeleteNewsletterAsync(Guid NewsletterId)
    {
        NewsletterEntity newsletter = await _newsletterRepository
            .GetByIdAsync(g => g.Id == NewsletterId);
        await _newsletterRepository.DeleteAsync(newsletter);
    }

    public async Task<PaginatedList<NewsletterDto>> GetNewslettersAsync(Pagination pagination)
    {
        IQueryable<NewsletterEntity> query = _newsletterRepository.GetByQuery();
       
        PaginatedList<NewsletterDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.Email!.Contains(pagination!.keyword) );
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<NewsletterEntity, NewsletterDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task InsertNewsletterAsync(NewsletterDto Newsletter)
    {
        NewsletterEntity newsletterEntity = Newsletter.Adapt<NewsletterEntity>();
        await _newsletterRepository.InsertAsync(newsletterEntity);
    }
}
