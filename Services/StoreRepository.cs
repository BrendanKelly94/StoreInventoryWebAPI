using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module1.Data;
using Module1.Models;

namespace Module1.Services
{
    public class StoreRepository : IStore
    {
        private ProductsDbContext productsDbContext;

        public StoreRepository(ProductsDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }

        public Store GetStore(int id)
        {
            var store = productsDbContext.Stores.SingleOrDefault(m => m.StoreId == id);
            return store;
        }

        public IEnumerable<Store> GetStores()
        {
            return productsDbContext.Stores;
        }

        public void AddStore(Store store)
        {
            productsDbContext.Stores.Add(store);
            productsDbContext.SaveChanges(true);
        }

        public void UpdateStore(Store store)
        {
            productsDbContext.Stores.Update(store);
            productsDbContext.SaveChanges(true);
        }

        public void DeleteStore(int id)
        {
            var store = productsDbContext.Stores.Find(id);
            productsDbContext.Stores.Remove(store);
            productsDbContext.SaveChanges(true);
        }
    }
}
