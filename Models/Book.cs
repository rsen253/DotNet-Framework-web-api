﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}