using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Request
{
    public class CreateUser : User,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<User>>
    {
        public string? Password { get; set; }
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string CreateUserName { get; set; } = string.Empty;
    }
}
