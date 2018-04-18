using Module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Services
{
    public interface ICompany
    {
        IEnumerable<Company> GetCompany();
        
    }
}
