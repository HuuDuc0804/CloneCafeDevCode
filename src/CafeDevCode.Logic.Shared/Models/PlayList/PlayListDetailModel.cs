using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Shared.Models
{
    public class PlayListDetailModel : PlayList
    {
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}
