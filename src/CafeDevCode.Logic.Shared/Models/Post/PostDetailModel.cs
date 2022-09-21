using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic.Shared.Models
{
    public class PostDetailModel : Post
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Post> Relates { get; set; } = new List<Post>();
        public Author? Author { get; set; }
    }
}
