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
	/// <summary>
	/// 
	/// </summary>
	/// <param name="user"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task SignUpAsync(UserDto user, CancellationToken cancellationToken=default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="user"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task SignInAsync(UserDto user,CancellationToken cancellation=default);
	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	Task SignOutAsync();
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Id"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task<SidebarDto> GetProfileInfoForSidebarAsync
		(Guid Id,CancellationToken cancellation);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="Id"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task<ProfileDto> GetProfileInformationAsync(Guid Id, CancellationToken cancellation = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="profile"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task UpdateProfileAsync(ProfileDto profile,CancellationToken cancellationToken=default);	
}
