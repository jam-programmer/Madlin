using Application.Common.Extension;
using Domain.Entities.Blog;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Services.Blog;

public class BlogService : IBlogService
{
    readonly ITagRepository _tagRepository;
    readonly IBlogCategoryRepository _categoryRepository;
    readonly IBlogTagRepository _blogTagRepository;
    readonly IBlogRepository _blogRepository;
    readonly IContextProvider _contextProvider;
    public BlogService(IBlogRepository blogRepository,
        IBlogCategoryRepository categoryRepository,
        ITagRepository tagRepository,
        IBlogTagRepository blogTagRepository,
        IContextProvider contextProvider)
    {
        _tagRepository = tagRepository;
        _categoryRepository = categoryRepository;
        _blogRepository = blogRepository;
        _blogTagRepository = blogTagRepository;
        _contextProvider = contextProvider;
    }

    public async Task DeleteBlogAsync(Guid Id, CancellationToken cancellation = default)
    {
        BlogEntity blogEntity = await _blogRepository.GetByIdAsync(g => g.Id == Id);
        if (blogEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        blogEntity.IsDeleted = true;
        await _blogRepository.UpdateAsync(blogEntity, cancellation);
    }

    public async Task<BlogDto> GetBlogAsync(Guid Id, CancellationToken cancellation = default)
    {
        BlogEntity blogEntity = await _blogRepository.GetByIdAndJoinAsync(Id, cancellation);
        if (blogEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        BlogDto blogDto = blogEntity.Adapt<BlogDto>();
        List<Guid>? TagIds = await _blogTagRepository.GetKeyTagsByBlogIdAsync(blogEntity.Id, cancellation);
        blogDto.Tags = TagIds;
        return blogDto;

    }

    public async Task<BlogDetailDto> GetBlogByUrlNameAsync(string urlName)
    {
        IQueryable<BlogEntity> query = _blogRepository.GetByQuery();
        query = query.Include(i => i.User).Include(i => i.Category);
        BlogEntity? blogEntity=await query.FirstOrDefaultAsync(f=>f.UrlName==urlName);
        return blogEntity.Adapt<BlogDetailDto>();
    }

    public async Task<PaginatedList<BlogDto>> GetBlogsAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<BlogEntity, BlogDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.CategoryTitleFa, s => s.Category!.TitleFa)
            .Map(d => d.UrlName, s => s.UrlName)
            .Map(d => d.ImagePath, s => s.ImagePath).Compile();
        IQueryable<BlogEntity> query = _blogRepository.GetByQuery();
        query = query.Include(i => i.Category);
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword) || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<BlogDto>
        model = await query.MappingedAsync<BlogEntity, BlogDto>(pagination.currentPage,
            pagination.pageSize, count, total, config);
        return model;
    }

    public async Task<PaginatedList<BlogItemDto>> GetBlogsByCategoryUrlNamAsync(PaginationWithKey pagination)
    {
        Guid CategoryId =await _categoryRepository.GetCategoryIdByUrlNameAsync(pagination.Key);
        TypeAdapterConfig config = new();
        config.NewConfig<BlogEntity, BlogItemDto>()
             .Map(d => d.CategoryTitleEn, s => s.Category!.TitleEn)
             .Map(d => d.CategoryTitleFa, s => s.Category!.TitleFa)
             .Map(d => d.TitleFa, s => s.TitleFa)
             .Map(d => d.TitleEn, s => s.TitleEn)
             .Map(d => d.ShortDescriptionFa, s => s.ShortDescriptionFa)
             .Map(d => d.ShortDescriptionEn, s => s.ShortDescriptionEn)
             .Map(d => d.UrlName, s => s.UrlName)
             .Map(d => d.ImagePath, s => s.ImagePath)
             .Map(d => d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())
             .Compile();
        IQueryable<BlogEntity> query = _blogRepository.GetByQuery();
        query = query.Where(w=>w.CategoryId== CategoryId).Include(i => i.Category);
        query = query.OrderByDescending(d=>d.CreatedAt);
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword)
            || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<BlogItemDto>
        model = await query.MappingedAsync<BlogEntity, BlogItemDto>(pagination.currentPage,
            pagination.pageSize, count, total, config);
        return model;
    }

    public async Task<PaginatedList<BlogItemDto>> GetBlogsByTagAsync(PaginationWithKey pagination)
    {
        IList<Guid> BlogIds = await _tagRepository.GetBlogIdsByTagAsync(pagination.Key);
        TypeAdapterConfig config = new();
        config.NewConfig<BlogEntity, BlogItemDto>()
             .Map(d => d.CategoryTitleEn, s => s.Category!.TitleEn)
             .Map(d => d.CategoryTitleFa, s => s.Category!.TitleFa)
             .Map(d => d.TitleFa, s => s.TitleFa)
             .Map(d => d.TitleEn, s => s.TitleEn)
             .Map(d => d.ShortDescriptionFa, s => s.ShortDescriptionFa)
             .Map(d => d.ShortDescriptionEn, s => s.ShortDescriptionEn)
             .Map(d => d.UrlName, s => s.UrlName)
             .Map(d => d.ImagePath, s => s.ImagePath)
             .Map(d => d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())
             .Compile();
        IQueryable<BlogEntity> query = _blogRepository.GetByQuery();
        query = query.Where(w => BlogIds.Contains(w.Id)).Include(i => i.Category);
        query = query.OrderByDescending(d => d.CreatedAt);
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword)
            || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<BlogItemDto>
        model = await query.MappingedAsync<BlogEntity, BlogItemDto>(pagination.currentPage,
            pagination.pageSize, count, total, config);
        return model;
    }

    public async Task<PaginatedList<BlogItemDto>>
        GetBlogsForBlogListPageAsync(Pagination pagination)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<BlogEntity, BlogItemDto>()
             .Map(d => d.CategoryTitleEn, s => s.Category!.TitleEn)
             .Map(d => d.CategoryTitleFa, s => s.Category!.TitleFa)
             .Map(d => d.TitleFa, s => s.TitleFa)
             .Map(d => d.TitleEn, s => s.TitleEn)    
             
             .Map(d => d.ShortDescriptionFa, s => s.ShortDescriptionFa)
             .Map(d => d.ShortDescriptionEn, s => s.ShortDescriptionEn)


             .Map(d => d.UrlName, s => s.UrlName)
             .Map(d => d.ImagePath, s => s.ImagePath)
             .Map(d => d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())
             .Compile();
        IQueryable<BlogEntity> query = _blogRepository.GetByQuery();
        query = query.Include(i => i.Category);
        if (string.IsNullOrEmpty(pagination.keyword) is false)
        {
            query = query.Where(w => w.TitleEn!.Contains(pagination.keyword)
            || w.TitleFa!.Contains(pagination.keyword));
        }
        int count = query.Count().PageCount(pagination.pageSize);
        int total = query.Count();
        PaginatedList<BlogItemDto>
        model = await query.MappingedAsync<BlogEntity, BlogItemDto>(pagination.currentPage,
            pagination.pageSize, count, total, config);
        return model;
    }

    public async Task<IReadOnlyList<BlogItemDto>> GetNewestBlogsAsync(int take, CancellationToken cancellation = default)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<BlogEntity, BlogItemDto>()
            .Map(d=>d.CategoryTitleEn,s => s.Category!.TitleEn)
            .Map(d=>d.CategoryTitleFa,s => s.Category!.TitleFa)
            .Map(d=>d.TitleFa,s => s.TitleFa)
            .Map(d=>d.TitleEn,s => s.TitleEn)
            .Map(d=>d.UrlName,s => s.UrlName)
            .Map(d=>d.ImagePath, s => s.ImagePath)
            .Map(d=>d.CreatedAt, s => s.CreatedAt!.Value.PersianDateWithTime())
            .Compile();
        IList<BlogEntity> blogs=await _blogRepository.GetNewestBlogsAsync(take,cancellation);
        return blogs.Adapt<IReadOnlyList<BlogItemDto>>(config);
    }

    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>> GetTagsByBlogIdAsync(Guid Id, CancellationToken cancellation = default)
    {
        IReadOnlyList<BlogTagEntity> tags = await _blogTagRepository.GetTagsByBlogIdAsync(Id, cancellation);
        return tags.Select(s => new ItemGeneric<Guid, string>()
        {
            Id = s.Tag!.Id,
            Title = s.Tag!.TitleFa
        }).ToList();
    }

    public async Task InsertBlogAsync(BlogDto blog, CancellationToken cancellation = default)
    {
        IExecutionStrategy strategy = _contextProvider.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            IDbContextTransaction transaction = await _contextProvider.BeginTransactionAsync();
            try
            {
                Random random = new();
                string baseUrl = (blog.UrlName ?? blog.TitleEn!).GenerateUrl();
                string url = baseUrl;
                while (await _blogRepository.ExistAsync(e => e.UrlName == url, cancellation))
                {
                    url = $"{baseUrl}{random.Next(1, 100)}";
                }


                BlogEntity blogEntity = blog.Adapt<BlogEntity>();
                blogEntity.UrlName = url;

                blogEntity.ImagePath = blog.ImageFile!.UploadImage("Blog");
                blogEntity.CreatedAt = DateTime.Now;
                await _blogRepository.InsertAsync(blogEntity, cancellation);

                if (blog.Tags != null && blog.Tags.Any())
                {
                    List<BlogTagEntity> tags = [];
                    foreach (Guid tagId in blog.Tags)
                    {
                        BlogTagEntity blogTagEntity = new()
                        {
                            BlogId = blogEntity.Id,
                            TagId = tagId
                        };
                        tags.Add(blogTagEntity);
                    }
                    await _blogTagRepository.InsertAsync(tags, cancellation);
                }
                await transaction.CommitAsync(cancellation);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellation);
                throw new InternalException(Messages.InternalError);
            }
        });
    }

    public async Task UpdateBlogAsync(BlogDto blog, CancellationToken cancellation = default)
    {
        BlogEntity blogEntity = await _blogRepository.GetByIdAsync(g => g.Id == blog.Id);
        if (blogEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        bool isUrlDuplicate = await _blogRepository.ExistAsync(
       e => e.UrlName == blog.UrlName && e.Id != blog.Id, cancellation);
        if (isUrlDuplicate)
        {
            Random random = new();
            string baseUrl = (blog.UrlName ?? blog.TitleEn!).GenerateUrl();
            string url = baseUrl;
            while (await _blogRepository.ExistAsync(e => e.UrlName == url, cancellation))
            {
                url = $"{baseUrl}{random.Next(1, 100)}";
            }
            blog.UrlName = url;
        }
        IExecutionStrategy strategy = _contextProvider.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            IDbContextTransaction transaction = await _contextProvider.BeginTransactionAsync();
            try
            {
                var blogCreateDate= blogEntity.CreatedAt;
                blog.Adapt(blogEntity);
                if (blog.ImageFile != null)
                {
                    blogEntity.ImagePath = blog.ImageFile!.UploadImage("Blog");
                    blog.ImagePath!.RemoveImage("Blog");
                }
                blogEntity.CreatedAt = blogCreateDate;  
                await _blogRepository.UpdateAsync(blogEntity, cancellation);
                await _blogTagRepository.DeleteTagsByBlogIdAsync(blog.Id);
                if (blog.Tags != null && blog.Tags.Any())
                {

                    List<BlogTagEntity> tags = [];
                    foreach (Guid tagId in blog.Tags)
                    {
                        BlogTagEntity blogTagEntity = new()
                        {
                            BlogId = blogEntity.Id,
                            TagId = tagId
                        };
                        tags.Add(blogTagEntity);
                    }
                    await _blogTagRepository.InsertAsync(tags, cancellation);
                }
                await transaction.CommitAsync(cancellation);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellation);
                throw new InternalException(Messages.InternalError);
            }
        });
    }
}
