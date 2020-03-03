using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostCreate
    {
        [Required]
        [Range(1, 30)]
        public string Title { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(240, ErrorMessage ="There are too many characters in this post.")]
        public string Text { get; set; }

        [Required]
        public User Author { get; set; }

    }
}
