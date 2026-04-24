using Application.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Security.Claims;


namespace EndPoint_Ui.Attributes;

public class AdminAuthorize : AuthorizeAttribute,
    IAuthorizationFilter
{
    string _controllerName;
    public AdminAuthorize(string controllerName)
    {
        _controllerName = controllerName;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity!.IsAuthenticated)
        {
            ClaimsPrincipal user = context.HttpContext.User;

            Claim claim = user.Claims!.FirstOrDefault(f => f.Type == "Route")!;
            List<RouteDto>? routes = JsonConvert.DeserializeObject<List<RouteDto>>(claim!.Value);


            if (routes!.Any(a => a.ControllerName == _controllerName) is false)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();

            }
        }
        else
        {
            context.Result =new Microsoft.AspNetCore.Mvc.RedirectResult("/SignIn");
        }





    }
}
