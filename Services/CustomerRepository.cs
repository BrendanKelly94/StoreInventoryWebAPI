using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Data;
using Module1.Models;

namespace Module1.Services
{
    public class CustomerRepository : ICustomer
    {
        private ProductsDbContext productsDbContext;

        public CustomerRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        public Customer GetCustomer(int id)
        {
            var customer =  productsDbContext.Customers.SingleOrDefault(m => m.CustomerId == id);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return productsDbContext.Customers;
        }

        public void AddCustomer(Customer customer)
        {
            productsDbContext.Customers.Add(customer);
            productsDbContext.SaveChanges(true);
        }

        public void UpdateCustomer(Customer customer)
        {
     
            productsDbContext.Customers.Update(customer);
            productsDbContext.SaveChanges(true);
        }
    }
}
