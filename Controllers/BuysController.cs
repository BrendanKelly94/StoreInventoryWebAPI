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
    [Route("api/Buys")]
    public class BuysController : Controller
    {
        private IBuys buysRepository;

        public BuysController(IBuys _buysRepository)
        {
            buysRepository = _buysRepository;
        }

        // GET: api/Buys
        [HttpGet]
        public IEnumerable<Buys> Get()
        {
            return buysRepository.GetBuys();
        }

        // POST: api/Buys/
        [HttpPost("{ProductId}")]
        public IActionResult Post([FromBody]Buys buy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            buysRepository.AddBuy(buy);

            try
            {
                buysRepository.UpdateProductQuantity(buy.ProductId, buy.Quantity);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                return NotFound("Not Enough in Stock for this item");
            }
            
            return Ok("Bought a product and updated quantity");
        }

    }
}