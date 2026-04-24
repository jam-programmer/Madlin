using Application.Common.Extension;
using Domain.Entities.Blog;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Tag;

public class TagService : ITagService
{
    readonly ITagRepository _tagRepository;
    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public async Task DeleteTagAsync(Guid Id, CancellationToken cancellation = default)
    {
        TagEntity tagEntity = await _tagRepository.GetByIdAsync(g => g.Id == Id);
        if (tagEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        tagEntity.IsDeleted = true;
        await _tagRepository.UpdateAsync(tagEntity, cancellation);
    }

    public async Task<TagDto> GetTagByIdAsync(Guid Id, CancellationToken cancellation = default)
    {
        TagEntity tagEntity = await _tagRepository.GetByIdAsync(g => g.Id == Id);
        if (tagEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return tagEntity.Adapt<TagDto>();
    }

    public async Task<TagDto> GetTagByKeyAsync(string key)
    {
        TagEntity tagEntity = await _tagRepository
            .GetByIdAsync(g => g.Key == key);
        return tagEntity.Adapt<TagDto>();
    }

    public async Task<PaginatedList<TagDto>> GetTagsAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        IQueryable<TagEntity> query = _tagRepository.GetByQuery();
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword) || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<TagDto>
        model = await query.MappingedAsync<TagEntity, TagDto>(pagination.currentPage,
            pagination.pageSize, count, total);
        return model;
    }

    public async Task<IReadOnlyList<TagDto>> GetTagsAsync()
    {
        List<TagEntity> tags = await _tagRepository
            .GetListAsync();
        return tags.Adapt<IReadOnlyList<TagDto>>();
    }

    public async Task<IReadOnlyList<TagDto>> GetTagsByBlogIdAsync(Guid BlogId)
    {
        IList<TagEntity> tags= await _tagRepository .GetTagsByBlogIdAsync(BlogId);
        return tags.Adapt<IReadOnlyList<TagDto>>();
    }

    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>> GetTagsForDropDownAsync(string search)
    {
        IQueryable<TagEntity> query = _tagRepository.GetByQuery();

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

    public async Task InsertTagAsync(TagDto tag, CancellationToken cancellation = default)
    {
        TagEntity tagEntity = tag.Adapt<TagEntity>();
        tagEntity.Key = Application.Common.Extension.Common.GenerateRandomString(15);
        await _tagRepository.InsertAsync(tagEntity, cancellation);
    }

    public async Task UpdateTagAsync(TagDto tag, CancellationToken cancellation = default)
    {
        TagEntity tagEntity = await _tagRepository.GetByIdAsync(g => g.Id == tag.Id);
        if (tagEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        tagEntity.TitleFa = tag.TitleFa;
        tagEntity.TitleEn = tag.TitleEn;
        await _tagRepository.UpdateAsync(tagEntity, cancellation);
    }
}
