﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Comment
    {
        public string Text { get; set; }

        public User Name { get; set; }
        public virtual User Author { get; set; }
        public Post CommentPost { get; set; }
    }
}
