using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Data;
using Module1.Models;

namespace Module1.Services
{
    public class CompanyRepository : ICompany
    {
        private ProductsDbContext productsDbContext;

        public CompanyRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        public IEnumerable<Company> GetCompany()
        {
            return productsDbContext.Company;
        }
    }
}
