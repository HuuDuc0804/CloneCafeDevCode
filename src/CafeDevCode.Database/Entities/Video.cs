using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Entities
{
    public class Video : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UrlMeta { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Iframe { get; set; } = string.Empty;
        public DateTime? PostDate { get; set; }
        public string Remark { get; set; } = string.Empty;
    }
}
