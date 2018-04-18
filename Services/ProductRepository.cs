using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Models;
using Module1.Data;

namespace Module1.Services
{
    public class ProductRepository : IProduct
    {
        private ProductsDbContext productsDbContext;

        public ProductRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }
       

        public IEnumerable<Product> GetProductsBySearch(string searchProduct, int currentPage, int currentPageSize)
        {
            if(searchProduct == null)
            {
                return productsDbContext.Products;
            }
            else
            {
                var products = productsDbContext.Products.Where(p => p.ProductName.StartsWith(searchProduct));
                var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();

                return items;
            }
                    
        }
        

        //Get data by page
        /*
        [HttpGet]
        public IEnumerable<Product> Get(int? pageNumber, int? pageSize)
        {

            var products = from p in productsDbContext.Products.OrderBy(a => a.ProductId) select p;
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;

            var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();

            return items;

        }
        */

        //Get sorted records
        /*
        [HttpGet]
        public IEnumerable<Product> Get(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = productsDbContext.Products.OrderByDescending(p => p.ProductPrice);
                    break;
                case "asc":
                    products = productsDbContext.Products.OrderBy(p => p.ProductPrice);
                    break;
                default:
                    products = productsDbContext.Products;
                    break;
            }
            return products;
        }
        */

    

        public void AddProduct(Product product)
        {
            productsDbContext.Products.Add(product);
            productsDbContext.SaveChanges(true);
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }


        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }

    }
}
