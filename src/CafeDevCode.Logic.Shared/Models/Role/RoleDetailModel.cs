using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Shared.Models
{
    public class RoleDetailModel : IdentityRole<string>
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}
