using Application.Common;
using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Comment;
using Application.Services.Product;
using Application.Services.ProductCategory;
using Application.Services.Wish;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EndPoint_Ui.Controllers;

public class ProductController : Controller
{
    readonly IWishService _wishService;
    readonly ICommentService _commentService;
    readonly IProductCategoryService _productCategoryService;
    readonly IProductService _productService;
    public ProductController(IProductCategoryService productCategoryService,
        IWishService wishService,
        ICommentService commentService,IProductService productService)
    {
        _commentService = commentService;
        _productCategoryService = productCategoryService;
        _productService = productService;
        _wishService = wishService;
    }

    [HttpGet]
    [Route("/Products")]
    public async Task<IActionResult> Products(int currentPage = 1,
        int pageSize = 12, string search = null)
    {
         ViewBag.Keyword = search;
         PaginatedList<ProductItemDto> products =
         await _productService.GetProductsForProductListPageAsync(new Pagination()
         {
             currentPage = currentPage,
             pageSize = pageSize,
             keyword = search
         });
        return View(products.Adapt<PaginatedList<CardProductViewModel>>());
    }






    [HttpGet]
    [Route("/Product/Category/{UrlName}")]
    public async Task<IActionResult> Category
        (string UrlName,int currentPage = 1, int pageSize = 12, string search = null)
    {
        ViewBag.UrlName= UrlName;
        ViewBag.Keyword=search; 
        PaginatedList<ProductItemDto> products =
            await _productService.GetProductsByCategoryAsync(new PaginationWithKey()
            {
                currentPage = currentPage,
                pageSize = pageSize,
                keyword = search,
                Key = UrlName
            });
        CategoryPageDto category=await _productCategoryService.GetCategoryByUrlNameAsync(UrlName);
        ValueTuple<PaginatedList<CardProductViewModel>,CategoryPageViewModel> model = new();
        model.Item1 = products.Adapt<PaginatedList<CardProductViewModel>>();
        model.Item2=category.Adapt<CategoryPageViewModel>();
        return View(model);
    }


    [HttpGet]
    [Route("/Product/Detail/{UrlName}")]
    public async Task<IActionResult> Detail(string UrlName)
    {
        ProductDetailDto productDetail =
            await _productService.GetProductDetailByUrlName(UrlName);
        return View(productDetail.Adapt<ProductDetailViewModel>());
    }


    [HttpPost]
    public async Task<IActionResult> SubmitQuestion([FromBody] CommentModel model)
    {
        try
        {
            await _commentService.InsertCommentAsync(new CommentDto()
            {
                ProductId = model.productId,
                Title = model.title,
                Text = model.message,
                UserPhoneNumber = model.phonenumber,
                UserPublicName = model.phonenumber
            });
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }





    [HttpPost]
    public async Task<IActionResult> AddToWishList([FromBody] WishModel model)
    {
        try
        {
            if (User.Identity!.IsAuthenticated is false)
            {
                return new JsonResult(new
                {
                    IsSuccess = false,
                    Message = CultureInfo.CurrentUICulture.Name == "en-US" ? "Please sign in to your account" : "لطفا وارد حساب کاربری شوید",
                });
            }
            await _wishService.AddToWishListAsync(new WishDto()
            {
                ProductId = model.ProductId,
                UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            });
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (InternalException ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
       
    }


    [HttpPost]
    public async Task<IActionResult> RemoveFromWishList([FromBody] WishModel model)
    {
        try
        {
          
            await _wishService.RemoveFromWishListAsync(new WishDto()
            {
                ProductId = model.ProductId,
                UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            });
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
       
        catch (Exception ex)
        {
            return BadRequest(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }

    }

}
