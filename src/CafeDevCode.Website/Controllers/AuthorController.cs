using AutoMapper;
using CafeDevCode.Database;
using CafeDevCode.Logic.Queries.Interface;
using CafeDevCode.Logic.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeDevCode.Website.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorQueries authorQueries;

        public AuthorController(IAuthorQueries authorQueries)
        {
            this.authorQueries = authorQueries;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int Id)
        {
            var model = new AuthorDetailModel();
            if (Id > 0)
            {
                model = authorQueries.GetDetail(Id);
            }
            return View(model);
        }
    }
   
}
