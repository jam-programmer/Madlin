using Domain.Entities.System;

namespace Domain.Contract;

public interface IAdvertisingBannerRepository : IRepository<AdvertisingBannerEntity>
{
    Task<AdvertisingBannerEntity> GetAdvertisingBannerAsync(CancellationToken cancellationToken);
}
