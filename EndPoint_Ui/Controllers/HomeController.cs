using Application.DataTransferObject;
using Application.Services.Message;
using Application.Services.Newsletter;
using Application.Services.Page;
using Application.Services.Question;
using Application.Services.Setting;
using EndPoint_Ui.Models;
using Mapster;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint_Ui.Controllers
{
    public class HomeController : Controller
    {
        readonly IPageService _pageService;
        readonly IQuestionService _questionService;
        readonly IMessageService _messageService;
        readonly INewsletterService _newsletterService;
        readonly ISettingService _settingService;
        public HomeController(ISettingService settingService,
            IPageService pageService,
            IMessageService messageService, IQuestionService questionService,
            INewsletterService newsletterService)
        {
            _pageService = pageService;
            _questionService= questionService;
            _messageService = messageService;
            _newsletterService = newsletterService;
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("/Page/{Url}")]
        public async Task<IActionResult> Page(string Url)
        {
           PageDto page = await _pageService.GetPageByUrlAsync(Url);
            return View(page.Adapt<PageViewModel>());
        }







        [HttpGet]
        [Route("About")]
        public async Task<IActionResult> About()
        {
            AboutDto about = await _settingService.GetAboutAsync();
            return View(about.Adapt<AboutViewModel>());
        }
        [HttpGet]
        [Route("/Contact-Us")]
        [Route("/ContactUs")]
        [Route("/Contact")]

        public async Task<IActionResult> Contact()
        {
            InformationDto information = await _settingService.GetInformationAsync();
            return View(information.Adapt<InformationViewModel>());
        }


        [Route("/Faq")]
        public async Task<IActionResult> Faq()
        {
            IReadOnlyList<QuestionDto>list=await _questionService.GetQuestionsAsync();
            return View(list.Adapt<IReadOnlyList<QuestionViewModel>>());
        }


  




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //asp-controller="Home" asp-action="ChangeLanguage" asp-route-culture="fa-IR"
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return Redirect(Request.Headers["Referer"].ToString());
        }



        [Route("/404")]
        public IActionResult NotFound() => View();

        [Route("/RegistrationRules")]
        public async Task<IActionResult> RegistrationRules()
        {
            RegistrationRuleDto model = await _settingService.GetRegistrationRulesAsync();
            return View(model.Adapt<RegistrationRuleViewModel>());
        }






        [HttpPost]
        public async Task<IActionResult> JoinToNewsletter([FromBody] NewsletterModel model)
        {
            try
            {

                await _newsletterService.InsertNewsletterAsync(new NewsletterDto()
                {
                    Email = model.Email,
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
        public async Task<IActionResult> SendMessage([FromBody] MessageModel model)
        {
            try
            {

                await _messageService.InsertMessageAsync(model.Adapt<MessageDto>());
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
}
