using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Common.Shared.Model
{
    public class BaseCommandResultWithData<T> : BaseCommandResult
    {
        public T? Data { get; set; }
    }
}
