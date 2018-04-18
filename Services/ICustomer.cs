using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Models;

namespace Module1.Services
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int id);

        void AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);
    }
}
