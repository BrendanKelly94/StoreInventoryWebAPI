using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Services
{
    public interface IBuys
    {
        //CRUD
        IEnumerable<Buys> GetBuys();

        Buys GetBuy(int id);

        void AddBuy(Buys product);

        void UpdateProductQuantity(int id, int quantity);
    }
}
