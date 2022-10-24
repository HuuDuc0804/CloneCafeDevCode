using Microsoft.AspNetCore.Mvc;

namespace CafeDevCode.Website.Controllers
{
    public class PlayListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
