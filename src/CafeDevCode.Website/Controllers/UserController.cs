using CafeDevCode.Utils.Extensions;
using CafeDevCode.Website.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeDevCode.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdminLogin(LoginViewModel model)
        {
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AdminLoginSubmit(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var command = model.ToCommand();
                var result = await mediator.Send(command);
                if (result.Success)
                {
                    var user = result.Data!;
                    var claims = new List<Claim>()
                    {
                        new Claim("UserName", user.UserName),
                        new Claim("AuthorId", user.AuthorId ?? string.Empty),
                    };

                    var claimIdentities = new List<ClaimsIdentity>()
                    {
                        new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme),
                    };

                    var claimPrincipal  = new ClaimsPrincipal(claimIdentities);
                    await HttpContext.SignInAsync(claimPrincipal);

                    if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    
                }
                else
                {
                    model.ErrorMessage = result.Messages;
                    return RedirectToAction("AdminLogin", model);
                }
                
            }
            else
            {
                model.ErrorMessage = ModelState.GetError();
                return RedirectToAction("AdminLogin", model);
            }
        }
    }
}
