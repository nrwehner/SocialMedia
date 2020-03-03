using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReplyListItem
    {
        public string Text { get; set; }

        public User Name { get; set; }
        public virtual User Author { get; set; }
        public Post CommentPost { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
