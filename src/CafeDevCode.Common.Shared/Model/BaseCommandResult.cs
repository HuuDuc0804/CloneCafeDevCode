using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Common.Shared.Model
{
    public class BaseCommandResult
    {
        public bool Success { get; set; }
        public string Messages { get; set; } = string.Empty;
        public List<BaseError> Errors { get; set; } = new List<BaseError>();
    }
}
