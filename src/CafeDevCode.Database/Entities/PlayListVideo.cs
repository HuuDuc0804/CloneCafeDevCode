using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Database.Entities
{
    public class PlayListVideo : BaseEntity
    {
        public int Id { get; set; }
        public int? PlayListId { get; set; }
        public int? VideoId { get; set; }
    }
}
