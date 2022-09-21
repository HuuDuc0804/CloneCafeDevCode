using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Handler
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRole, BaseCommandResultWithData<IdentityRole>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;

        public UpdateRoleHandler(AppDatabase database,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.roleManager = roleManager;
        }
        public Task<BaseCommandResultWithData<IdentityRole>> Handle(UpdateRole request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<IdentityRole>();
            try
            {
                var role = database.Roles.FirstOrDefault(r => r.Id == request.Id);

                if (role != null)
                {

                }
                else
                {

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
