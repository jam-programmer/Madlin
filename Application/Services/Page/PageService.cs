using Application.Common.Extension;
using Domain.Entities.System;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Page;

public class PageService : IPageService
{
    readonly IPageRepository _repository;
    public PageService(IPageRepository pageRepository)
    {
        _repository = pageRepository;
    }
    public async Task DeletePageAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        PageEntity Page = await _repository.GetByIdAsync(g => g.Id == Id);
        if (Page == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Page.IsDeleted = true;
        await _repository.UpdateAsync(Page, cancellationToken);
    }

    public async Task<IReadOnlyList<PageItemDto>> GetItemPagesByPositionAsync(int show)
    {
       IReadOnlyList<PageEntity> pages=await _repository.GetPagesByShowPositionAsync(show);
        return pages.Adapt<IReadOnlyList<PageItemDto>>();  
    }

    public async Task<PageDto> GetPageByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        PageEntity? Page = await _repository.GetByIdAsync(g => g.Id == Id);
        if (Page == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return Page.Adapt<PageDto>();
    }

    public async Task<PageDto> GetPageByUrlAsync(string Url)
    {
        PageEntity pageEntity=await _repository.GetPageByUrlAsync(Url);
        return pageEntity.Adapt<PageDto>();
    }

    public async Task<PaginatedList<PageDto>> GetPagesAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        IQueryable<PageEntity> query = _repository.GetByQuery();


        PaginatedList<PageDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||
                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<PageEntity, PageDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }
    public async Task InsertPageAsync(PageDto Page, CancellationToken cancellationToken = default)
    {
        Random random = new();
        string baseUrl = Application.Common.Extension.Common.GenerateRandomString();
        string url = baseUrl;
        while (await _repository.ExistAsync(e => e.Url == url, cancellationToken))
        {
            url = $"{baseUrl}{random.Next(1, 100)}";
        }



        PageEntity PageEntity = Page.Adapt<PageEntity>();

        PageEntity.Url = url;
        await _repository.InsertAsync(PageEntity, cancellationToken);
    }
    public async Task UpdatePageAsync(PageDto Page, CancellationToken cancellationToken = default)
    {
        bool isUrlDuplicate = await _repository.ExistAsync(
            e => e.Url == Page.Url && e.Id != Page.Id, cancellationToken);
        if (isUrlDuplicate)
        {
            Random random = new();
            string baseUrl = Application.Common.Extension.Common.GenerateRandomString();
            string url = baseUrl;
            while (await _repository.ExistAsync(e => e.Url == url, cancellationToken))
            {
                url = $"{baseUrl}{random.Next(1, 100)}";
            }
            Page.Url = url;
        }



        PageEntity PageEntity = await _repository.GetByIdAsync(g => g.Id == Page.Id);
        if (Page == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Page.Adapt(PageEntity);

        await _repository.UpdateAsync(PageEntity, cancellationToken);
    }
}
