using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public int? PostIđ { get; set; }
        public int? VideoId { get; set; }
    }
}
