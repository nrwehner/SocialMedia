﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PostDetail
    {
        
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
