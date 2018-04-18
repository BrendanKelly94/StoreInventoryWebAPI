using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Services
{
    public interface IStore
    {
        IEnumerable<Store> GetStores();

        Store GetStore(int id);

        void AddStore(Store store);

        void UpdateStore(Store store);

        void DeleteStore(int id);
        
    }
}
