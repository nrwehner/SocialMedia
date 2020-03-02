using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public User Author { get; set; }
    }
}
