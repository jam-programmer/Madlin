using Application.Common;
using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Identity.Role;

public interface IRoleService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="role"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task InsertRoleAsync(RoleDto role, CancellationToken cancellation = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="role"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task UpdateRoleAsync(RoleDto role, CancellationToken cancellation = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="roleId"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task DeleteRoleAsync(Guid roleId,CancellationToken cancellation=default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="roleId"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>
	Task<RoleDto> GetRoleByIdAsync(Guid roleId, CancellationToken cancellation = default);
	/// <summary>
	/// 
	/// </summary>
	/// <param name="pagination"></param>
	/// <param name="cancellation"></param>
	/// <returns></returns>

	Task<PaginatedList<RoleDto>> GetRolesAsync(Pagination pagination,CancellationToken cancellation = default);

}
