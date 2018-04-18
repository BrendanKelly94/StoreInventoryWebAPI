using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Data;
using Module1.Models;

namespace Module1.Services
{
    public class BuysRepository : IBuys
    {
        private ProductsDbContext productsDbContext;

        public BuysRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        public void AddBuy(Buys buy)
        {
           productsDbContext.Buys.Add(buy);
           productsDbContext.SaveChanges(true);
         
        }

        public void UpdateProductQuantity(int id, int quantity)
        {
            var product = productsDbContext.Products.Find(id);

            if(product.Quantity - quantity >= 0)
            {
                product.Quantity = product.Quantity - quantity;
                productsDbContext.Products.Update(product);  
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough in stock of this product");
            }

            if (product.Quantity - quantity == 0)
            {
                productsDbContext.Products.Remove(product);
            }
                productsDbContext.SaveChanges(true);

        }

        public Buys GetBuy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Buys> GetBuys()
        {
            return productsDbContext.Buys;
        }
    }
}
