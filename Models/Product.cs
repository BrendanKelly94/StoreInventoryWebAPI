using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public int Quantity { get; set; }

        //foreign key
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}
