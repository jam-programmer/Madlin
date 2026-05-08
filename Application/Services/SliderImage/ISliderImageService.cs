namespace Application.Services.SliderImage;

public interface ISliderImageService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SliderImage"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertSliderImageAsync(SliderImageDto SliderImage, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SliderImage"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task UpdateSliderImageAsync(SliderImageDto SliderImage, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SliderImageId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<SliderImageDto> GetSliderImageByIdAsync(Guid SliderImageId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SliderImageId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeleteSliderImageAsync(Guid SliderImageId, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagination"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PaginatedList<SliderImageDto>> GetSliderImagesAsync(Pagination pagination,
        CancellationToken cancellation = default);
    
}
