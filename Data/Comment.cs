using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Comment
    {
        public string Text { get; set; }
        public User Author { get; set; }
        public Post CommentPost { get; set; }
    }
}
