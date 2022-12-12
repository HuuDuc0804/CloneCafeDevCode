using CafeDevCode.Logic.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeDevCode.Website.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexPortal()
        {
            return View();
        }
        public IActionResult Detail(int Id)
        {
            var model = new VideoDetailModel();
            return View(model);
        }
        public IActionResult DetailPortal()
        {
            return View();
        }
    }
}
