using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Entities
{
    public class PlayList : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UrlMeta { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public int? SortIndex { get; set; }
    }
}
