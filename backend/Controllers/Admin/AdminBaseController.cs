using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarTechShowcase.Controllers.Admin;

public abstract class AdminBaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (HttpContext.Session.GetString("AdminAuth") != "true")
        {
            context.Result = new RedirectResult("/Admin/Login");
            return;
        }
        base.OnActionExecuting(context);
    }
}
