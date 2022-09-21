using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {

            CreateMap<CreateRole, IdentityRole>();
            CreateMap<IdentityRole, RoleSummaryModel>()
                .ReverseMap();
            CreateMap<IdentityRole, RoleDetailModel>()
                .ReverseMap();
        }
    }
}
