using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, BaseCommandResultWithData<User>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UpdateUserHandler(AppDatabase database,
            IMapper mapper,
            UserManager<User> userManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public Task<BaseCommandResultWithData<User>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<User>();
            try
            {
                var user = userManager.FindByNameAsync(request.UpdateUserName).Result;
                if (user != null)
                {
                    user.Email = request.Email;
                    user.PhoneNumber = request.PhoneNumber;
                    user.AuthorId = request.AuthorId;
                    var updateResult = userManager.UpdateAsync(user).Result;
                    if (updateResult.Succeeded)
                    {
                        result.Success = true;
                        result.Data = user;
                    }
                    else
                    {
                        result.Messages = String.Join("-", updateResult.Errors.Select(x => x.Description));
                    }
                }
                else
                {
                    result.Messages = $"Can't find user with name: {request.UpdateUserName} to update";
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
