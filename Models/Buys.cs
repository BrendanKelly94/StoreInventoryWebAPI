using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Buys
    {
        public int BuysId { get; set; }
        public int Quantity { get; set; }
        
        //foreign keys
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
