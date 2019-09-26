using Microsoft.AspNetCore.Mvc;
using ZXH.ZentaoNotify.Web.Core.Controllers;

namespace ZXH.ZentaoNotify.Host.Controllers
{
    public class HomeController: ZentaoNotifyControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}