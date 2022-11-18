using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public DeleteUserHandler(AppDatabase database,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public Task<BaseCommandResult> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var user = userManager.FindByNameAsync(request.DeleteUserName).Result;
                if (user != null)
                {
                    var deleleResult = userManager.DeleteAsync(user).Result;
                    if (deleleResult.Succeeded)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        result.Messages = string.Join("-", deleleResult.Errors.Select(x => x.Description));
                    }
                }
                else
                {
                    result.Messages = $"Can't find user with name {request.DeleteUserName} to delete!";
                }
            }
            catch (Exception ex)
            {
                result.Messages = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
