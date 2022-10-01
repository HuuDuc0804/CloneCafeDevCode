using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class LoginHandler : IRequestHandler<Login, BaseCommandResultWithData<User>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LoginHandler(AppDatabase database,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public Task<BaseCommandResultWithData<User>> Handle(Login request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<User>();
            try
            {
                var user = userManager.FindByNameAsync(request.UserName).Result;
                if (user != null)
                {
                    var isPasswordValid = userManager.CheckPasswordAsync(user, request.Password).Result;
                    if (isPasswordValid)
                    {
                        result.Success = true;
                        result.Data = user;
                    }
                    else
                    {
                        result.Messages = AppGlobal.InvalidPassword;
                    }
                }
                else
                {
                    result.Messages = AppGlobal.InvalidUserName;
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
