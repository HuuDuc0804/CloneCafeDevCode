using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Request
{
    public class Login : IRequest<BaseCommandResultWithData<User>>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? RememberPassword { get; set; }
    }
}
