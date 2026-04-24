using Application.Common.Extension;
using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Picture;

public class PictureService : IPictureService
{
    readonly IPictureRepository _pictureRepository;
    public PictureService(IPictureRepository pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }
    public async Task DeletePictureAsync(Guid Id, CancellationToken cancellation = default)
    {
        PictureEntity Picture = await _pictureRepository
            .GetByIdAsync(g => g.Id == Id);
        if (Picture == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        Picture.IsDeleted = true;
        await _pictureRepository.UpdateAsync(Picture, cancellation);
    }

    public async Task<IReadOnlyList<PictureDto>> GetPictureAsync(Guid ProductId, CancellationToken cancellation = default)
    {
        IQueryable<PictureEntity> query = _pictureRepository.GetByQuery();
        return await query.Select(s=>new PictureDto()
        {
            Id = s.Id,
            Path = s.Path,  
        }).ToListAsync();   
    }

    public async Task InsertPictureAsync(PictureDto picture, CancellationToken cancellation = default)
    {
        PictureEntity pictureEntity = new()
        {
            ProductId = picture.ProductId,
            Path = picture.File!.UploadImage("Product"),
         
        };
        await _pictureRepository.InsertAsync(pictureEntity, cancellation);
    }
}
