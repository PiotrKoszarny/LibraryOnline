using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class OrderBooks
    {
        public int OrderBooksId { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }

        public List<Book> Book { get; set; }
        public Order Order { get; set; }
    }
}