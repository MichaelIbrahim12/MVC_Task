using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading;

namespace MVC_Task.Controllers
{
    public class LanguageController : BaseController
    {
        public IActionResult Arabic()
        {
            HttpContext.Session.SetString("Lang", "ar-EG");
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }       
        public IActionResult English()
        {
            HttpContext.Session.SetString("Lang", "us-EN");
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }
    }
}
