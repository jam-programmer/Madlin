namespace Application.Services.Newsletter;
public interface INewsletterService
{
    Task InsertNewsletterAsync(NewsletterDto Newsletter);
    Task DeleteNewsletterAsync(Guid NewsletterId);
    Task<PaginatedList<NewsletterDto>> GetNewslettersAsync(Pagination pagination);
}
