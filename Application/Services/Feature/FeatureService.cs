
using Application.Common.Extension;
using Domain.Entities.Product;
using Mapster;

namespace Application.Services.Feature;

public class FeatureService : IFeatureService
{
    readonly IFeatureRepository _featureRepository;
    public FeatureService(IFeatureRepository featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task DeleteFeatureAsync(Guid Id, CancellationToken cancellation = default)
    {
        FeatureEntity featureEntity = await _featureRepository.GetByIdAsync(g => g.Id == Id);
        if (featureEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        featureEntity.IsDeleted = true;
        await _featureRepository.UpdateAsync(featureEntity, cancellation);
    }

    public async Task<FeatureDto> GetFeatureByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        FeatureEntity featureEntity = await _featureRepository.GetByIdAsync(g => g.Id == Id);
        if (featureEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        return featureEntity.Adapt<FeatureDto>();
    }

    public async Task<PaginatedList<FeatureDto>> GetFeaturesAsync(PaginationWithParent pagination, CancellationToken cancellationToken = default)
    {
        IQueryable<FeatureEntity> query = _featureRepository.GetByQuery();
        TypeAdapterConfig config = new();
        config.NewConfig<FeatureEntity, FeatureDto>()
            .Map(d => d.TitleFa, s => s.TitleFa)
            .Map(d => d.ValueFa, s => s.ValueFa)
            .Map(d => d.Id, s => s.Id)
            .Compile();
        PaginatedList<FeatureDto> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w =>
                 w.TitleEn!.Contains(pagination!.keyword) ||

                 w.TitleFa!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<FeatureEntity, FeatureDto>
                (pagination!.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }

    public async Task<IReadOnlyList<FeatureDto>> GetFeaturesByProductIdAsync(Guid Id)
    {
        IList<FeatureEntity> features=await _featureRepository
            .GetFeaturesByProductIdAsync(Id);
        return features.Adapt<IReadOnlyList<FeatureDto>>();
    }

    public async Task InsertFeatureAsync(FeatureDto feature, CancellationToken cancellation = default)
    {
        FeatureEntity featureEntity = feature.Adapt<FeatureEntity>();
        await _featureRepository.InsertAsync(featureEntity, cancellation);
    }

    public async Task UpdateFeatureAsync(FeatureDto feature, CancellationToken cancellation = default)
    {
        FeatureEntity featureEntity = await _featureRepository.GetByIdAsync(g => g.Id == feature.Id);
        if (featureEntity == null)
        {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        feature.Adapt(featureEntity);
        await _featureRepository.UpdateAsync(featureEntity, cancellation);
    }
}
