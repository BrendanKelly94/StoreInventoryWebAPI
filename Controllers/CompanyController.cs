using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;
using Module1.Services;

namespace Module1.Controllers
{
    [Produces("application/json")]
    [Route("api/Company")]
    public class CompanyController : Controller
    {
        private ICompany companyRepository;

        public CompanyController(ICompany _companyRepository)
        {
            companyRepository = _companyRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return companyRepository.GetCompany();
        }
    }
}