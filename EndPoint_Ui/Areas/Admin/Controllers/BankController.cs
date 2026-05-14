using Application.Common;
using Application.DataTransferObject;
using Application.Services.Bank;
using EndPoint_Ui.Areas.Admin.Models.Common;
using EndPoint_Ui.Areas.Admin.Models.Bank;
using EndPoint_Ui.Attributes;
using Microsoft.AspNetCore.Mvc;
using Mapster;
namespace EndPoint_Ui.Areas.Admin.Controllers;
[Area("Admin")]
[AdminAuthorize("Bank")]
public class BankController : Controller
{
	readonly IBankService _BankService;
	public BankController(IBankService BankService)
	{
		_BankService = BankService;
	}
	[HttpGet]
	public async Task<IActionResult> Index([FromQuery] Pagination pagination)
	{
		ViewBag.Keyword = pagination.keyword;
		PaginatedList<BankDto> model = await _BankService.
			GetBanksAsync(pagination);
		return View(model.Adapt<PaginatedList<BankViewModel>>());
	}

	[HttpGet]
	public IActionResult Create()
	{
		ViewBag.Alert = null;
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateBankModel model)
	{
		if (ModelState.IsValid is false)
		{
			return View(model);
		}
		try
		{
			await _BankService.InsertBankAsync(model.Adapt<BankDto>());
			return RedirectToAction(nameof(Index));
		}
		catch (Exception ex)
		{

			ViewBag.Alert = ex.Message;
			return View(model);
		}
	}

	[HttpGet]
	public async Task<IActionResult> Edit(Guid Id)
	{
		ViewBag.Alert = null;
		BankDto Bank = await _BankService.GetBankByIdAsync(Id);
		return View(Bank.Adapt<EditBankModel>());
	}
	[HttpPost]
	public async Task<IActionResult> Edit(EditBankModel model)
	{
		if (ModelState.IsValid is false)
		{
			return View(model);
		}
		try
		{
			await _BankService.UpdateBankAsync(model.Adapt<BankDto>());
			return RedirectToAction(nameof(Index));
		}
		catch (Exception ex)
		{

			ViewBag.Alert = ex.Message;
			return View(model);
		}
	}

	[HttpPost]
	public async Task<IActionResult> Delete([FromBody] DeleteModel input)
	{
		try
		{

			await _BankService.DeleteBankAsync(input.Id);
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
