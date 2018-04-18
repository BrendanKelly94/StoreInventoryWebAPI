using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        //1 to many
        public ICollection<Store> Stores { get; set; }
    }
}
