using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Text { get; set; }

        public User Name { get; set; }
        public virtual User Author { get; set; }
        public Post CommentPost { get; set; }
    }
}
