using Application.Common.Extension;
using Domain.Entities.Identity;
using Domain.Entities.Product;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.ProductCategory;

public class ProductCategoryService : IProductCategoryService
{
    readonly IProductCategoryRepository _productCategoryRepository;
    public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task DeleteProductCategoryAsync(Guid ProductCategoryId, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity = await _productCategoryRepository.
            GetByIdAsync(g => g.Id == ProductCategoryId);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        categoryEntity.IsDeleted = true;
        await _productCategoryRepository.UpdateAsync(categoryEntity,cancellation);
    }

    public async Task<IReadOnlyList<ItemGeneric<Guid, string>>> GetCategoriesForDropDownAsync(string search)
    {
        IQueryable<CategoryEntity> query = _productCategoryRepository.GetByQuery();

        if (string.IsNullOrEmpty(search) is false)
        {
            query = query.Where(w => w.TitleFa!.Contains(search));
        }
        return await query
            .Take(10).Select(s=>new ItemGeneric<Guid, string>()
        {
            Id = s.Id,
            Title=s.TitleFa
        }).ToListAsync();   
            
    }

    public async Task<PaginatedList<ProductCategoryDto>> GetProductCategoriesAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        IQueryable<CategoryEntity> query = _productCategoryRepository.GetByQuery();
        TypeAdapterConfig config = new();
        config.NewConfig<CategoryEntity, ProductCategoryDto>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.IsFeatured, s => s.IsFeatured)
            .Map(d => d.IconImagePath, s => s.IconImagePath)
            .Map(d => d.Id, s => s.Id)
            .Compile();
        PaginatedList<ProductCategoryDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||
              
                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<CategoryEntity, ProductCategoryDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task<ProductCategoryDto> GetProductCategoryByIdAsync(Guid ProductCategoryId, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity = await _productCategoryRepository.
            GetByIdAsync(g => g.Id == ProductCategoryId);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return categoryEntity.Adapt<ProductCategoryDto>();  
    }

    public async Task InsertProductCategoryAsync(ProductCategoryDto productCategory, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity=productCategory.Adapt<CategoryEntity>();
        if (productCategory.IconImageFile != null) 
        {
            categoryEntity.IconImagePath = productCategory.IconImageFile.UploadImage("ProductCategory");
        }
        if (productCategory.MainImageFile != null) 
        {
            categoryEntity.MainImagePath = productCategory.MainImageFile.UploadImage("ProductCategory");

        }
        await _productCategoryRepository
            .InsertAsync(categoryEntity,cancellation);
    }

    public async Task UpdateProductCategoryAsync(ProductCategoryDto productCategory, CancellationToken cancellation = default)
    {
        CategoryEntity categoryEntity = await _productCategoryRepository.
         GetByIdAsync(g => g.Id == productCategory.Id);
        if (categoryEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        productCategory.Adapt(categoryEntity);
        if (productCategory.IconImageFile != null)
        {
            categoryEntity.IconImagePath = productCategory.IconImageFile.UploadImage("ProductCategory");
            productCategory.IconImagePath!.RemoveImage("ProductCategory");
        }
        if (productCategory.MainImageFile != null)
        {
            categoryEntity.MainImagePath = productCategory.MainImageFile.UploadImage("ProductCategory");
            productCategory.MainImagePath!.RemoveImage("ProductCategory");
        }
        await _productCategoryRepository .UpdateAsync(categoryEntity,cancellation);
    }
}
