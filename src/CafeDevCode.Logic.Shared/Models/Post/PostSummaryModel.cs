using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Shared.Models
{
    public class PostSummaryModel : Post
    {
        public string AuthorName { get; set; } = string.Empty;
        public int TotalComment { get; set; }
    }
}
