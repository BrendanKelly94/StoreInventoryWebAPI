using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public ICollection<Product> Products { get; set; }

        //foreign key
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
