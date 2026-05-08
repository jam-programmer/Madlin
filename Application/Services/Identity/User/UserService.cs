using Application.Common.Extension;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Globalization;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Services.Identity.User;

public class UserService : IUserService
{
    readonly IRoleRouteRepository _roleRouteRepository;
    readonly SignInManager<UserEntity> _signInManager;
    readonly RoleManager<RoleEntity> _roleManager;
    readonly UserManager<UserEntity> _userManager;
    readonly IContextProvider _contextProvider;
    public UserService(UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager,
        IRoleRouteRepository roleRouteRepository,

        SignInManager<UserEntity> signInManager,
        IContextProvider contextProvider)
    {
        _roleRouteRepository = roleRouteRepository;
        _signInManager = signInManager;
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
        config.NewConfig<UserEntity, UserDto>()
            .Map(d => d.Email, s => s.Email)
            .Map(d => d.PhoneNumber, s => s.PhoneNumber)
            .Map(d => d.UserName, s => s.UserName)
            .Map(d => d.FullName, s => s.FullName)
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.IsActive, s => s.EmailConfirmed)
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
                    userEntity.EmailConfirmed = user.IsActive;
                    userEntity.PhoneNumberConfirmed = user.IsActive;
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
                    throw;
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



    public async Task SignUpAsync(UserDto user, CancellationToken cancellationToken = default)
    {
        StringBuilder stringBuilder = new StringBuilder();
        IQueryable<RoleEntity> query = _roleManager.Roles.AsQueryable();
        RoleEntity? roleEntity = await query.FirstOrDefaultAsync(f => f.IsCustomer == true, cancellationToken);
        if (roleEntity == null)
        {
            throw new InternalException();
        }
        IExecutionStrategy Strategy = _contextProvider.CreateExecutionStrategy();

        await Strategy.ExecuteAsync(async () =>
        {
            StringBuilder textError = new StringBuilder();
            UserEntity userEntity = user.Adapt<UserEntity>();
            userEntity.PhoneNumberConfirmed = true;
            userEntity.EmailConfirmed = true;
            using (var transaction = await _contextProvider.BeginTransactionAsync())
            {
                try
                {
                    var resultInsertUser = await _userManager.CreateAsync(userEntity);
                    if (!resultInsertUser.Succeeded)
                    {
                        foreach (var error in resultInsertUser.Errors)
                        {
                            textError.AppendLine(error.Description);
                        }
                        throw new InternalException(textError.ToString());

                    }


                    var resultInserUserRole = await _userManager.AddToRoleAsync(userEntity, roleEntity.Name!);
                    if (!resultInserUserRole.Succeeded)
                    {
                        foreach (var error in resultInserUserRole.Errors)
                        {
                            textError.AppendLine(error.Description);
                        }
                        await transaction.RollbackAsync();
                        throw new InternalException(textError.ToString());
                    }
                    var resultInserUserPassword = await _userManager
                    .AddPasswordAsync(userEntity, user.Password!);
                    if (!resultInserUserPassword.Succeeded)
                    {
                        foreach (var error in resultInserUserPassword.Errors)
                        {
                            textError.AppendLine(error.Description);
                        }
                        await transaction.RollbackAsync();
                        throw new InternalException(textError.ToString());
                    }
                    await transaction.CommitAsync();

                    Claim fullName = new Claim("fullName", $"{userEntity.FullName} "!);

                    Claim IdClaim = new Claim("Id", userEntity.Id.ToString()!);

                    List<Claim> claims = new List<Claim>();
                    claims.Add(IdClaim);
                    claims.Add(fullName);

                    await _userManager.AddClaimsAsync(userEntity, claims);



                    await _signInManager.SignInAsync(userEntity, false);
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();
                    throw;
                }

            }
        });
    }

    public async Task SignInAsync(UserDto user, CancellationToken cancellation = default)
    {
        UserEntity? userEntity = await _userManager.FindByNameAsync(user.UserName!);

        if (user == null)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {
                throw new InternalException("The username or password is incorrect");

            }
            else
            {
                throw new InternalException("نام کاربری یا رمز عبور اشتباه است");

            }

        }




 
        if (userEntity.PhoneNumberConfirmed is false || userEntity.EmailConfirmed is false)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {

                throw new InternalException("Your account has been disabled");
            }
            else
            {
                throw new InternalException("حساب کاربری شما غیرفعال شده است");


            }
        }













        bool checkPassword = await _userManager.CheckPasswordAsync(userEntity!, user.Password!);
        if (checkPassword is false)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {

                throw new InternalException("The username or password is incorrect");
            }
            else
            {

                throw new InternalException("نام کاربری یا رمز عبور اشتباه است");
            }
        }
        bool canSignIn = await _signInManager.CanSignInAsync(userEntity!);
        if (!canSignIn)
        {
            if (CultureInfo.CurrentUICulture.Name == "en-US")
            {

                throw new InternalException("You are not authorized to enter");
            }
            else
            {
                throw new InternalException("شما مجاز به ورود نیستید");


            }
        }
        IList<string> role = await _userManager.GetRolesAsync(userEntity!);

        var query = _roleRouteRepository.GetByQuery();
        var routes = await query.Include(i => i.RouteEntity).Where(i => role.Contains(i.RoleEntity.Name))
            .ToListAsync();


        if (routes != null)
        {
            var userClaims = await _userManager.GetClaimsAsync(userEntity);

            var oldClaims = userClaims.ToList();
            if (oldClaims != null)
            {
                await _userManager.RemoveClaimsAsync(userEntity, oldClaims!);
            }
            List<RouteDto> userRoutes = [];
            foreach (var route in routes)
            {
                RouteDto routeView = new()
                {
                    Icon = route.RouteEntity.Icon,
                    Id = route.RouteEntity.Id,
                    Name = route.RouteEntity.Name,
                    Order = route.RouteEntity.Order,
                    Url = route.RouteEntity.Url,
                    ParentId = route.RouteEntity.ParentId,
                    UniqueId = route.RouteEntity.UniqueId,
                    ControllerName = route.RouteEntity.ControllerName,
                };
                userRoutes.Add(routeView);
            }
            string? roleName = role.FirstOrDefault();
            RoleEntity? currentUserRole = await _roleManager.Roles.FirstOrDefaultAsync(f => f.Name == roleName);

            Claim fullName = new Claim("fullName", $"{userEntity.FullName} "!);
            Claim roleClaim = new Claim("Role", roleName!);
            Claim IdClaim = new Claim("Id", userEntity.Id.ToString()!);
            Claim roleAccess = new Claim("RoleAccess", currentUserRole!.IsCustomer.ToString());
            Claim routeClaim = new Claim("Route", JsonSerializer.Serialize(userRoutes));

            List<Claim> claims = new List<Claim>();
            claims.Add(routeClaim);
            claims.Add(roleAccess);
            claims.Add(IdClaim);
            claims.Add(roleClaim);
            claims.Add(fullName);

            await _userManager.AddClaimsAsync(userEntity, claims);
        }
        await _signInManager.SignInAsync(userEntity!, true);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<SidebarDto> GetProfileInfoForSidebarAsync(Guid Id, CancellationToken cancellation)
    {
        UserEntity? userEntity = await _userManager.FindByIdAsync(Id.ToString());
        return new SidebarDto()
        {
            Id = Id,
            Email = userEntity?.Email,
            FullName = userEntity!.FullName
        };
    }

    public async Task<ProfileDto> GetProfileInformationAsync(Guid Id, CancellationToken cancellation = default)
    {
        UserEntity? userEntity = await _userManager.FindByIdAsync(Id.ToString());
        return new ProfileDto()
        {
            Id = Id,
            Email = userEntity?.Email,
            FullName = userEntity?.FullName,
            PhoneNumber = userEntity?.PhoneNumber,
        };
    }

    public async Task UpdateProfileAsync(ProfileDto profile, CancellationToken cancellationToken = default)
    {
        StringBuilder message = new();
        UserEntity? userEntity = await _userManager.FindByIdAsync(profile.Id.ToString());
        userEntity!.Email = profile!.Email!;
        userEntity.FullName = profile.FullName;
        userEntity.PhoneNumber = profile.PhoneNumber;
        IdentityResult result = await _userManager.UpdateAsync(userEntity);
        if (result.Succeeded is false)
        {
            foreach (IdentityError item in result.Errors)
            {
                message.AppendLine(item.Description + "/");
            }
            throw new InternalException(message.ToString());
        }

        if (string.IsNullOrEmpty(profile.Password) is false)
        {
            bool CheckOldPassword = await _userManager.CheckPasswordAsync(userEntity, profile.OldPassword!);
            if (CheckOldPassword is false)
            {
                throw new InternalException(CultureInfo.CurrentUICulture.Name == "en-US" ?
                    "The old password is incorrect" : "رمز عبور قدیمی اشتباه است");
            }

            IdentityResult resultRemovePassword = await _userManager.RemovePasswordAsync(userEntity);
            if (resultRemovePassword.Succeeded is false)
            {
                foreach (IdentityError item in resultRemovePassword.Errors)
                {
                    message.AppendLine(item.Description + "/");
                }
                throw new InternalException(message.ToString());
            }

            IdentityResult resultAddPassword = await _userManager.AddPasswordAsync(userEntity, profile.Password);
            if (resultAddPassword.Succeeded is false)
            {
                foreach (IdentityError item in resultAddPassword.Errors)
                {
                    message.AppendLine(item.Description + "/");
                }
                throw new InternalException(message.ToString());
            }
        }
    }
}

