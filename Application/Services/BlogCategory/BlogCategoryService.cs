
using Application.Common.Extension;
using Domain.Entities.Blog;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.BlogCategory;

public class BlogCategoryService : IBlogCategoryService
{
    readonly IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task DeleteBlogCategoryAsync(Guid Id, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity = await _blogCategoryRepository.GetByIdAsync(g => g.Id == Id);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        categoryEntity.IsDeleted = true;
        await _blogCategoryRepository.UpdateAsync(categoryEntity, cancellation);
    }

    public async Task<PaginatedList<BlogCategoryDto>> GetBlogCategoriesAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        IQueryable<CategoryEntity> query = _blogCategoryRepository.GetByQuery();
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword) || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<BlogCategoryDto>
        model = await query.MappingedAsync<CategoryEntity, BlogCategoryDto>(pagination.currentPage,
            pagination.pageSize, count, total);
        return model;
    }

    public async Task<BlogCategoryDto> GetBlogCategoryByIdAsync(Guid Id, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity = await _blogCategoryRepository.GetByIdAsync(g => g.Id == Id);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return categoryEntity.Adapt<BlogCategoryDto>();
    }

    public async Task InsertBlogCategoryAsync(BlogCategoryDto category, CancellationToken cancellation = default)
    {

        Random random = new();
        string baseUrl = (category.UrlName ?? category.TitleEn!).GenerateUrl();
        string url = baseUrl;
        while (await _blogCategoryRepository.ExistAsync(e => e.UrlName == url, cancellation))
        {
            url = $"{baseUrl}{random.Next(1, 100)}";
        }
        CategoryEntity categoryEntity = category.Adapt<CategoryEntity>();
        categoryEntity.UrlName = url;
        await _blogCategoryRepository.InsertAsync(categoryEntity, cancellation);
    }

    public async Task UpdateBlogCategoryAsync(BlogCategoryDto category, CancellationToken cancellation = default)
    {
        bool isUrlDuplicate = await _blogCategoryRepository.ExistAsync(
         e => e.UrlName == category.UrlName && e.Id != category.Id, cancellation);
        if (isUrlDuplicate)
        {
            Random random = new();
            string baseUrl = (category.UrlName ?? category.TitleEn!).GenerateUrl();
            string url = baseUrl;
            while (await _blogCategoryRepository.ExistAsync(e => e.UrlName == url, cancellation))
            {
                url = $"{baseUrl}{random.Next(1, 100)}";
            }
            category.UrlName = url;
        }
        CategoryEntity categoryEntity = await _blogCategoryRepository.GetByIdAsync(g => g.Id == category.Id);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        category.Adapt(categoryEntity);
        await _blogCategoryRepository.UpdateAsync(categoryEntity, cancellation);
    }

    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>> GetCategoriesForDropDownAsync(string search)
    {
        IQueryable<CategoryEntity> query = _blogCategoryRepository.GetByQuery();

        if (string.IsNullOrEmpty(search) is false)
        {
            query = query.Where(w => w.TitleFa!.Contains(search));
        }
        return await query
            .Take(10).Select(s => new ItemGeneric<Guid, string>()
            {
                Id = s.Id,
                Title = s.TitleFa
            }).ToListAsync();

    }

    public async Task<IReadOnlyList<BlogCategoryDto>> GetBlogCategoriesAsync()
    {
        List<CategoryEntity> categories = await _blogCategoryRepository
            .GetListAsync();
        return categories.Adapt<IReadOnlyList<BlogCategoryDto>>();
    }

    public async Task<BlogCategoryDto> GetBlogCategoryByUrlNameAsync(string urlName, CancellationToken cancellation = default)
    {
        CategoryEntity category = await
            _blogCategoryRepository.GetByIdAsync(g => g.UrlName == urlName);
        return category.Adapt<BlogCategoryDto>();
    }
}
