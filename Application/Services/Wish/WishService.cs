using Domain.Entities.Product;
using Mapster;
using System.Globalization;
using System.Web;

namespace Application.Services.Wish;

public class WishService : IWishService
{
    readonly IWishRepository _wishRepository;
    public WishService(IWishRepository wishRepository)
    {
        _wishRepository = wishRepository;
    }
    public async Task AddToWishListAsync(WishDto wish)
    {
        bool Exist=await _wishRepository.ExistAsync(a=>a.ProductId==wish.ProductId);
        if (Exist) 
        {
            string dir=  CultureInfo.CurrentUICulture.Name == "en-US" ? "ltr" : "rtl";
            string message = CultureInfo.CurrentUICulture.Name == 
                "en-US" ? $"- This product is in your favorites list <a style=\"color:blue\" onclick=\"RemoveFromWishList('{wish.ProductId}','{dir}')\" > click here to remove it from your favorites</a>" : $"این محصول در لیست علاقه مندی شما وجود دارد - <a style=\"color:blue\" onclick=\"RemoveFromWishList('{wish.ProductId}','{dir}')\">برای حذف از لیست علاقه مندی اینجا کلیک کنید</a>";
         
            throw new InternalException(message);
        }
        await _wishRepository.InsertAsync(wish.Adapt<WishEntity>());
    }

    public async Task RemoveFromWishListAsync(WishDto wish)
    {
       WishEntity wishEntity=await _wishRepository
            .GetByIdAsync(i => i.ProductId==wish.ProductId && i.UserId==wish.UserId);
        if (wishEntity == null) {
            throw new InternalException(Messages.NotFoundOnDb);
        }
        await _wishRepository.DeleteAsync(wishEntity);
    }
}
