using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Shared.Models
{
    public class VideoDetailModel : Video
    {
        public List<PlayList> PlayLists { get; set; } = new List<PlayList>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
