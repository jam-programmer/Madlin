using Application.Common.Extension;
using Domain.Entities.Product;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Product;

public class ProductService : IProductService
{
    readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task DeleteProductAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        ProductEntity product = await _repository.GetByIdAsync(g => g.Id == Id);
        if (product == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        product.IsDeleted = true;
        await _repository.UpdateAsync(product, cancellationToken);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        IQueryable<ProductEntity> query = _repository.GetByQuery();
        ProductEntity? product = await query.Include(i=>i.Category).
            FirstOrDefaultAsync(f => f.Id == Id,cancellationToken);   
        if (product == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return product.Adapt<ProductDto>();
    }

    public async Task<PaginatedList<ProductDto>> GetProductsAsync(Pagination pagination, CancellationToken cancellationToken = default)
    {
        IQueryable<ProductEntity> query = _repository.GetByQuery();
        query = query.Include(i => i.Category);
        TypeAdapterConfig config = new();
        config.NewConfig<ProductEntity, ProductDto>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.TitleEn, s => s.TitleEn)
            .Map(d => d.Price, s => s.Price)
            .Map(d => d.DiscountPrice, s => s.DiscountPrice)
            .Map(d => d.MainImagePath, s => s.MainImagePath)
            .Map(d => d.Quantity, s => s.Quantity)
            .Map(d => d.ProductCode, s => s.ProductCode)
            .Map(d => d.CategoryTitleFa, s => s.Category!.TitleFa)
            .Map(d => d.Id, s => s.Id)
            .Compile();

        PaginatedList<ProductDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||
                 w.ProductCode!.Contains(pagination!.keyword) ||
                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<ProductEntity, ProductDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task InsertProductAsync(ProductDto product, CancellationToken cancellationToken = default)
    {
        Random random = new();
        string baseUrl = (product.UrlName ?? product.TitleEn!).GenerateUrl();
        string url = baseUrl;
        while (await _repository.ExistAsync(e => e.UrlName == url, cancellationToken))
        {
            url = $"{baseUrl}{random.Next(1, 100)}";
        }

        bool CheckCode = await _repository.ExistAsync(e => e.ProductCode == product.ProductCode, cancellationToken);
        if (CheckCode)
        {
            throw new InternalException(Messages.ExistProductCode);
        }
        ProductEntity productEntity = product.Adapt<ProductEntity>();
        if (product.MainImageFile != null)
        {
            productEntity.MainImagePath = product.MainImageFile.UploadImage("Product");
        }
        if (product.HoverImageFile != null)
        {
            productEntity.HoverImagePath = product.HoverImageFile.UploadImage("Product");
        }
        productEntity.UrlName = url;
        await _repository.InsertAsync(productEntity, cancellationToken);
    }

    public async Task UpdateProductAsync(ProductDto product, CancellationToken cancellationToken = default)
    {
        bool isUrlDuplicate = await _repository.ExistAsync(
            e => e.UrlName == product.UrlName && e.Id != product.Id, cancellationToken);
        if (isUrlDuplicate)
        {
            Random random = new();
            string baseUrl = (product.UrlName ?? product.TitleEn!).GenerateUrl();
            string url = baseUrl;
            while (await _repository.ExistAsync(e => e.UrlName == url, cancellationToken))
            {
                url = $"{baseUrl}{random.Next(1, 100)}";
            }
            product.UrlName = url;
        }



        bool CheckCode = await _repository.ExistAsync
            (e => e.ProductCode == product.ProductCode &&
            e.Id != product.Id,
            cancellationToken);
        if (CheckCode)
        {
            throw new InternalException(Messages.ExistProductCode);
        }
        ProductEntity productEntity = await _repository.GetByIdAsync(g => g.Id == product.Id);
        if (product == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        product.Adapt(productEntity);
        if (product.MainImageFile != null)
        {
            productEntity.MainImagePath = product.MainImageFile.UploadImage("Product");
            product.MainImagePath!.RemoveImage("Product");
        }
        if (product.HoverImageFile != null)
        {
            productEntity.HoverImagePath = product.HoverImageFile.UploadImage("Product");
            product.HoverImagePath!.RemoveImage("Product");
        }
        await _repository.UpdateAsync(productEntity, cancellationToken);
    }
}
