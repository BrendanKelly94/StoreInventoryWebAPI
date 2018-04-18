using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Data;
using Module1.Models;
using Module1.Services;

namespace Module1.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private IProduct productRepository;

        public ProductsController(IProduct _productRepository)
        {
            productRepository = _productRepository;
        }
        
        // GET: api/Products
    
        [HttpGet]
        public IEnumerable<Product> GetBySearch(string searchProduct, int? pageNumber, int? pageSize)
        {
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            return productRepository.GetProductsBySearch(searchProduct, currentPage, currentPageSize);
        }
        
        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProduct(product);
            return StatusCode(StatusCodes.Status201Created);
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            try
            {
                productRepository.UpdateProduct(product);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record Found with this Id...");

            }
            return Ok("Product Updated");
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id); 
            return Ok("Product Deleted ...");

        }
    }
}
