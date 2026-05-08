using Application.Common.Extension;
using Domain.Entities.System;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SliderImage;

public class SliderImageService : ISliderImageService
{
    readonly ISliderImageRepository _repository;
    public SliderImageService(ISliderImageRepository repository)
    {
        _repository = repository;
    }
    public async Task DeleteSliderImageAsync(Guid SliderImageId, CancellationToken cancellation = default)
    {
        SliderImageEntity entity=await _repository.GetByIdAsync(g=>g.Id==SliderImageId);
        if (entity is null) 
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        entity.IsDeleted = true;
        await _repository.UpdateAsync(entity,cancellation);
    }

    public async Task<SliderImageDto> GetSliderImageByIdAsync(Guid SliderImageId, CancellationToken cancellation = default)
    {
        SliderImageEntity entity = await _repository.GetByIdAsync(g => g.Id == SliderImageId);
        if (entity is null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return entity.Adapt<SliderImageDto>();
    }

    public async Task<PaginatedList<SliderImageDto>> GetSliderImagesAsync(Pagination pagination, CancellationToken cancellation = default)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<SliderImageEntity, SliderImageDto>()
            .Map(d => d.Path, s => s.Path)
            .Map(d => d.End, s => s.End)
            .Map(d => d.Start, s => s.Start)
            .Map(d => d.Link, s => s.Link)
            .Map(d => d.Path, s => s.Path)
            .Map(d => d.Id, s => s.Id).Compile();

        IQueryable<SliderImageEntity> query = _repository.GetByQuery();
        PaginatedList<SliderImageDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.Title!.Contains(pagination!.keyword) ||

                 w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize); ;
        int total = query.Count();

        model = await query.MappingedAsync<SliderImageEntity, SliderImageDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;


    }

    public async Task InsertSliderImageAsync(SliderImageDto SliderImage, CancellationToken cancellation = default)
    {
        SliderImageEntity entity = SliderImage.Adapt<SliderImageEntity>();
        if(SliderImage.File is not null)
        {
            entity.Path = SliderImage.File.UploadImage("Slider");
        }
        await _repository.InsertAsync(entity,cancellation);
    }

    public async Task UpdateSliderImageAsync(SliderImageDto SliderImage, CancellationToken cancellation = default)
    {
        SliderImageEntity entity = await _repository.GetByIdAsync(g => g.Id == SliderImage.Id);
        if (entity is null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        SliderImage.Adapt(entity);
        if (SliderImage.File is not null)
        {
            entity.Path = SliderImage.File.UploadImage("Slider");
            SliderImage.Path!.RemoveImage("Slider");
        }
        await UpdateSliderImageAsync(SliderImage,   cancellation);
    }
}
