using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int ReaderId { get; set; }
        public int OrderBooksId { get; set; }

        public virtual Reader Reader { get; set; }
        public virtual List<OrderBooks> OrderBooks { get; set; }
    }
}