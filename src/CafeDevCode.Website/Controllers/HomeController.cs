using Microsoft.AspNetCore.Mvc;

namespace CafeDevCode.Website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
