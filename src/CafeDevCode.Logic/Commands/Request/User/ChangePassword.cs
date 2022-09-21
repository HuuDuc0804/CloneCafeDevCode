using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Commands.Request
{
    public class ChangePassword : IIdentifiedCommand,
        IRequest<BaseCommandResult>
    {
        public string? ChangePasswordUserName { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
