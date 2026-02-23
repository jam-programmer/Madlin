using Application.Common;
using Application.DataTransferObject;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Application.Common.CustomException;
using Application.Common.Resource;
using Mapster;
using Application.Common.Extension;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace Application.Services.Identity.Role;

public class RoleService : IRoleService
{
	readonly RoleManager<RoleEntity> _roleManager;
	public RoleService(RoleManager<RoleEntity> roleManager)
	{
		_roleManager = roleManager;
	}
	public async Task DeleteRoleAsync(Guid roleId, CancellationToken cancellation = default)
	{
		RoleEntity? role=await _roleManager.FindByIdAsync(roleId.ToString());
		if (role == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		role.IsDeleted = true;
		await _roleManager.UpdateAsync(role);	
	}

	public async Task<RoleDto> GetRoleByIdAsync(Guid roleId, CancellationToken cancellation = default)
	{
		RoleEntity? role = await _roleManager.FindByIdAsync(roleId.ToString());
		if (role == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		return role.Adapt<RoleDto>();
	}

	public async Task<PaginatedList<RoleDto>> GetRolesAsync(Pagination pagination, CancellationToken cancellation = default)
	{
		IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();
		if (!string.IsNullOrEmpty(pagination!.keyword))
		{
			query = query.Where(w => w.PersianName!.Contains(pagination.keyword));
		}
		int count = query.Count().PageCount(pagination!.pageSize); 
		int total = query.Count();
		PaginatedList<RoleDto> model =
		await query.MappingedAsync<RoleEntity, RoleDto>
				(pagination!.currentPage,
				pagination!.pageSize, count, total);
		return model;
	}

	public async Task<IReadOnlyList<ItemGeneric<string, string>>> GetRolesForDropDownAsync()
	{
		IQueryable<RoleEntity> query=_roleManager.Roles.AsQueryable();
		return await query.Select(s=>new ItemGeneric<string, string>()
		{
			Id=s.Name,
			Title	=s.PersianName
		}).ToListAsync();
	}

	public async Task InsertRoleAsync(RoleDto role, CancellationToken cancellation = default)
	{
		IQueryable<RoleEntity> query= _roleManager.Roles.AsQueryable();
		if (role.IsCustomer)
		{
			if (await query.AnyAsync(a => a.IsCustomer == true))
			{
				throw new InternalException(Messages.ExistRoleForCustomer);
			}
		}
		


		RoleEntity roleEntity=role.Adapt<RoleEntity>();
		await _roleManager.CreateAsync(roleEntity);
	}

	public async Task UpdateRoleAsync(RoleDto role, CancellationToken cancellation = default)
	{
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();

        if (role.IsCustomer)
        {
            if (await query.AnyAsync(a => a.IsCustomer == true && a.Id !=role.Id))
            {
                throw new InternalException(Messages.ExistRoleForCustomer);
            }
        }
        RoleEntity? roleEntity = await _roleManager.FindByIdAsync(role.Id.ToString());
		if (role == null)
		{
			throw new InternalException(Messages.NotFoundOnDb);
		}
		role.Adapt(roleEntity);
		await _roleManager.UpdateAsync(roleEntity!);
	}
}
