using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading;
using System.Globalization;

namespace MVC_Task.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.Session.GetString("Lang")!=null)
            {
                var Language = HttpContext.Session.GetString("Lang");
                Thread.CurrentThread.CurrentUICulture=new CultureInfo(Language);

            }
        }
    }
}
