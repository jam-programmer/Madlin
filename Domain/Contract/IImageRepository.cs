using Domain.Entities.System;

namespace Domain.Contract;
public interface IImageRepository : IRepository<ImageEntity>
{
    Task<IList<ImageEntity>> GetImagesAsync(CancellationToken cancellation);
}
