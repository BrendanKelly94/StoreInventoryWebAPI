 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required, StringLength(15)]
        public string CustomerName { get; set; }
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email fomat not valid")]
        public string CustomerEmail { get; set; }
       

    }
}
