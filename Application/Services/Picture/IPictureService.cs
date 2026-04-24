namespace Application.Services.Picture;

public interface IPictureService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="picture"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task InsertPictureAsync(PictureDto picture, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task DeletePictureAsync(Guid Id, CancellationToken cancellation = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ProductId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<IReadOnlyList<PictureDto>> GetPictureAsync(Guid ProductId, CancellationToken cancellation = default);
}
