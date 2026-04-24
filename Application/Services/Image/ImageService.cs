using Application.Common.Extension;
using Domain.Contract;
using Domain.Entities.System;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Image;

public class ImageService : IImageService
{
    readonly IImageRepository _imageRepository;
    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public async Task DeleteImageAsync(Guid Id, CancellationToken cancellationToken = default)
    {
       ImageEntity imageEntity=await _imageRepository.GetByIdAsync(g=>g.Id == Id);
        if(imageEntity is null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        imageEntity.IsDeleted = true;
        await _imageRepository.UpdateAsync(imageEntity,cancellationToken);
    }

    public async Task<IReadOnlyList<ImageDto>> GetImagesAsync(  CancellationToken cancellationToken = default)
    {
       IList<ImageEntity> list=await _imageRepository.
            GetImagesAsync(cancellationToken);

        return list.Adapt<IReadOnlyList<ImageDto>>();
    }

    public async Task InsertImageAsync(ImageDto imageDto, CancellationToken cancellationToken = default)
    {
        ImageEntity imageEntity = new();
        imageEntity.FilePath = imageDto.File!.UploadImage("Image");
        await _imageRepository.InsertAsync(imageEntity, cancellationToken);
    }
}
