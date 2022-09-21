using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class ChangPasswordHandler : IRequestHandler<ChangePassword, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ChangPasswordHandler(AppDatabase database,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public Task<BaseCommandResult> Handle(ChangePassword request,
            CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();
            try
            {
                var user = userManager.FindByNameAsync(request.ChangePasswordUserName).Result;
                if (user != null)
                {
                    var resetToken = userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetResult = userManager.ResetPasswordAsync(user, resetToken, request.NewPassword).Result;
                    if (resetResult.Succeeded)
                    {
                        result.Success = true;
                        result.Messages = AppGlobal.DefaultSuccessMessage;
                    }
                }
                else
                {
                    result.Messages = $"Can't find user with {request.UserName} to change password";
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
