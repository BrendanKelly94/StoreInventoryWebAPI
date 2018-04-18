using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Models;

namespace Module1.Services
{
    public interface IProduct
    {
        //CRUD
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsBySearch(string searchProduct, int currentPageNumber, int currentPageSize);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
        

    }
}
