using CafeDevCode.Common.Shared.Model;
using CafeDevCode.Logic.Commands.Request;
using CafeDevCode.Logic.Queries.Interface;
using CafeDevCode.Logic.Shared.Models;
using CafeDevCode.Utils.Extensions;
using CafeDevCode.Utils.Global;
using CafeDevCode.Website.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CafeDevCode.Website.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostQueries postQueries;
        private readonly IMediator mediator;

        public PostController(IPostQueries postQueries,
            IMediator mediator)
        {
            this.postQueries = postQueries;
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var model = new List<PostSummaryModel>();
            model = postQueries.GetAll();
            return PartialView(model);
        }

        public IActionResult IndexPortal()
        {
            return View();
        }
        public IActionResult Detail(int Id)
        {
            var model = new PostDetailModel();
            if (Id > 0)
            {
                model = postQueries.GetDetail(Id);
            }
            return View(model);
        }
        public IActionResult DetailPortal()
        {
            return View();
        }
        public async Task<ActionResult> SaveChange(PostDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetBaseFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Post>();
                if (model.Id == 0)
                {
                    var createCommand = model.ToCreateCommand();
                    commandResult = await mediator.Send(createCommand);
                }
                else
                {
                    var updateCommand = model.ToUpdateCommand();
                    commandResult = await mediator.Send(updateCommand);
                }
                if (commandResult.Success)
                {
                    return Json(new
                    {
                        success = true,
                        message = AppGlobal.DefaultSuccessMessage,
                        data = commandResult.Data,
                    });
                }
                else
                {
                    ModelState.AddModelError("", commandResult.Messages);
                    return Json(new { success = false, message = commandResult.Messages });
                }
            }
            else
            {
                return Json(new { success = false, message = ModelState.GetError() });
            }
        }
        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeletePost()
            {
                Id = Id,
                RequestId = HttpContext.Connection.Id,
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                UserName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserName")?.Value,
            };
            var result = await mediator.Send(command);
            return Json(new { success = result.Success, mesage = result.Messages });
        }
    }
}
