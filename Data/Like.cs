using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public Post LikedPost { get; set; }
        public User Liker { get; set; }
    }
}
