using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Image;

public interface IImageService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ImageDto>>GetImagesAsync(
        CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="imageDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task InsertImageAsync(ImageDto imageDto, CancellationToken cancellationToken=default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteImageAsync(Guid Id, CancellationToken cancellationToken=default);
}
