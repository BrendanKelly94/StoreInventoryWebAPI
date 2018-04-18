using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;
using Module1.Services;

namespace Module1.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomerController : Controller
    {
        private ICustomer customerRepository;

        public CustomerController(ICustomer _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerRepository.GetCustomers();
        }
    }
}
