using Application.Common;
using Application.DataTransferObject;

namespace Application.Services.Identity.User;

public interface IUserService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="user"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task InsertUserAsync(UserDto user,CancellationToken cancellationToken=default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="user"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task UpdateUserAsync(UserDto user,CancellationToken cancellationToken=default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="UserId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task DeleteUserAsync(Guid UserId,CancellationToken cancellationToken=default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="UserId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<UserDto> GetUserByIdAsync(Guid UserId, CancellationToken cancellationToken = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="pagination"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<PaginatedList<UserDto>> GetUsersAsync(Pagination pagination,CancellationToken cancellationToken=default);
}
