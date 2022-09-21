using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Common.Shared.Model
{
    public class BasePagingData<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }
        public int TotalPage { get; set; }
    }
}
