using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Contract;
using Application.DataTransferObject;
using Azure.Core;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Application.Common.Resource;

namespace Application.Services.Identity.User;

public class UserService : IUserService
{
	readonly RoleManager<RoleEntity> _roleManager;
	readonly UserManager<UserEntity> _userManager;
	readonly IContextProvider _contextProvider;
	public UserService(UserManager<UserEntity> userManager,
		RoleManager<RoleEntity> roleManager,
		IContextProvider contextProvider)
	{
		_contextProvider = contextProvider;
		_roleManager = roleManager;
		_userManager = userManager;
	}
	public async Task DeleteUserAsync(Guid UserId, CancellationToken cancellationToken = default)
	{
		UserEntity? user = await _userManager.FindByIdAsync(UserId.ToString());
		if (user == null)
		{
			throw new InternalException();
		}
		user.IsDeleted = true;
		await _userManager.UpdateAsync(user);
	}

	public async Task<UserDto> GetUserByIdAsync(Guid UserId, CancellationToken cancellationToken = default)
	{
		TypeAdapterConfig config = new();
		config.NewConfig<UserEntity, UserDto>()
			.Map(d => d.FullName, s => s.FullName)
			.Map(d => d.Id, s => s.Id)
			.Map(d => d.UserName, s => s.UserName)
			.Map(d => d.Email, s => s.Email)
			.Map(d => d.IsActive, s => s.PhoneNumberConfirmed)
			.Map(d => d.PhoneNumber, s => s.PhoneNumber).Compile();
		UserEntity? user = await _userManager.FindByIdAsync(UserId.ToString());
		if (user == null)
		{
			throw new InternalException();
		}
		UserDto userDto = user.Adapt<UserDto>(config);
		List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);
		userDto.Role = roles.FirstOrDefault();
		return userDto;

	}

	public async Task<PaginatedList<UserDto>> GetUsersAsync(Pagination pagination, CancellationToken cancellationToken = default)
	{
		IQueryable<UserEntity> query = _userManager.Users.AsQueryable();
		TypeAdapterConfig config = new();
		config.NewConfig<UserEntity,UserDto>()
			.Map(d=>d.Email,s=>s.Email)
			.Map(d=>d.PhoneNumber,s=>s.PhoneNumber)
			.Map(d=>d.UserName, s=>s.UserName)
			.Map(d=>d.FullName,s=>s.FullName)
			.Map(d=>d.Id, s=>s.Id)
			.Map(d=>d.IsActive, s=>s.EmailConfirmed)
			.Compile();
		PaginatedList<UserDto> model = new();
		if (!string.IsNullOrEmpty(pagination!.keyword))
		{
			query = query.Where(w =>
				 w.FullName!.Contains(pagination!.keyword) ||
				 w.PhoneNumber!.Contains(pagination!.keyword) ||
				 w.UserName!.Contains(pagination!.keyword));
		}
		int count = query.Count().PageCount(pagination!.pageSize); ;
		int total = query.Count();

		model = await query.MappingedAsync<UserEntity, UserDto>
				(pagination!.currentPage,
				pagination!.pageSize, count, total, config);
		return model;
	}

	public async Task InsertUserAsync(UserDto user, CancellationToken cancellationToken = default)
	{

		IExecutionStrategy strategy = _contextProvider.CreateExecutionStrategy();
		await strategy.ExecuteAsync(async () =>

		{
			using (IDbContextTransaction transaction = await _contextProvider.BeginTransactionAsync())
			{
				StringBuilder message = new();
				try
				{
					UserEntity userEntity = user.Adapt<UserEntity>();
					userEntity.EmailConfirmed=user.IsActive;	
					userEntity.PhoneNumberConfirmed=user.IsActive;	
					IdentityResult insertUserResult =
						await _userManager.CreateAsync(userEntity);
					if (insertUserResult.Succeeded is false)
					{
						
						foreach (IdentityError item in insertUserResult.Errors)
						{
							message.AppendLine(item.Description + "\n");
						}
						throw new InternalException(message.ToString());
					}



					IdentityResult insertRoleResult =
						await _userManager.AddToRoleAsync(userEntity, user.Role!);

					if (insertRoleResult.Succeeded is false)
					{
						await transaction.RollbackAsync();
						foreach (IdentityError item in insertRoleResult.Errors)
						{
							message.AppendLine(item.Description + "\n");
						}
						throw new InternalException(message.ToString());
					}

					IdentityResult insertPasswordResult =
					   await _userManager.AddPasswordAsync(userEntity, user.Password!);
					if (insertPasswordResult.Succeeded is false)
					{
						foreach (IdentityError item in insertPasswordResult.Errors)
						{
							message.AppendLine(item.Description + "/");
						}
						throw new InternalException(message.ToString());
					}

					await transaction.CommitAsync();
				}
				catch (Exception ex)
				{
					await transaction.RollbackAsync();
					throw ;
				}

			}

		});

	}

	public async Task UpdateUserAsync(UserDto user, CancellationToken cancellationToken = default)
	{
		StringBuilder message = new();

		IExecutionStrategy strategy = _contextProvider.CreateExecutionStrategy();
		await strategy.ExecuteAsync(async () =>

		{
			using (IDbContextTransaction transaction = await _contextProvider.BeginTransactionAsync())
			{
				try
				{
					UserEntity? userEntity = await _userManager.Users
						.FirstOrDefaultAsync(f => f.Id == user.Id, cancellationToken);

					if (userEntity == null)
					{
						throw new InternalException(Messages.NotFoundOnDb);
					}
					user.Adapt(userEntity);
                    userEntity.EmailConfirmed = user.IsActive;
                    userEntity.PhoneNumberConfirmed = user.IsActive;

                    IdentityResult updateUserResult =
						await _userManager.UpdateAsync(userEntity!);
					if (updateUserResult.Succeeded is false)
					{
						foreach (IdentityError item in updateUserResult.Errors)
						{
							message.AppendLine(item.Description + "/");
						}
						throw new InternalException(message.ToString());
					}



					IList<string> oldRoles = await _userManager.GetRolesAsync(userEntity);
					if (!oldRoles.Any())
					{
						await transaction.RollbackAsync();
						throw new InternalException(Messages.NotFoundUserRole);
					}

					IdentityResult removeOldRoles = await _userManager.RemoveFromRolesAsync(userEntity, oldRoles);

					if (removeOldRoles.Succeeded is false)
					{
						await transaction.RollbackAsync();
					
						foreach (IdentityError item in removeOldRoles.Errors)
						{
							message.AppendLine(item.Description + "/");
						}
						throw new InternalException(message.ToString());
					}

					IdentityResult insertRoleResult =
						await _userManager.AddToRoleAsync(userEntity, user.Role!);

					if (insertRoleResult.Succeeded is false)
					{
						await transaction.RollbackAsync();
					
						foreach (IdentityError item in insertRoleResult.Errors)
						{
							message.AppendLine(item.Description + "/");
						}
						throw new InternalException(message.ToString());
					}
					if (!string.IsNullOrEmpty(user.Password))
					{
						IdentityResult resultRemoveOldUserPassword =
		             await _userManager.RemovePasswordAsync(userEntity);
						if (!resultRemoveOldUserPassword.Succeeded)
						{
							foreach (var error in resultRemoveOldUserPassword.Errors)
							{
								message.AppendLine(error.Description);
							}
							throw new InternalException(message.ToString());
						}
						IdentityResult insertPasswordResult =
	   await _userManager.AddPasswordAsync(userEntity, user.Password!);
						if (insertPasswordResult.Succeeded is false)
						{
							foreach (IdentityError item in insertPasswordResult.Errors)
							{
								message.AppendLine(item.Description + "/");
							}
							throw new InternalException(message.ToString());
						}
					}

					await transaction.CommitAsync();
				}
				catch (Exception ex)
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
		});
	}
}
