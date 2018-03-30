using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int YearPublication { get; set; }


        public virtual Order Order { get; set; }
        public virtual List<Category> Category { get; set; }
    }
}