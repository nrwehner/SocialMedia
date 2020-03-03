using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Range(1,30)]
        public string Title { get; set; }
        [Required]
        [Range(1,240)]
        public string Text { get; set; }
       
        public User Name { get; set; }
        [Required]
        public virtual User Author { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
