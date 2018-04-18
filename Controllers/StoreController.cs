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
    [Route("api/Stores")]
    public class StoreController : Controller
    {
        private IStore storeRepository;

        public StoreController(IStore _storeRepository)
        {
            storeRepository = _storeRepository;
        }

        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return storeRepository.GetStores();
        }

        //api/Store/:id

        [HttpGet("{id}", Name = "Get")]
        public Store Get(int id)
        {
            return storeRepository.GetStore(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            storeRepository.AddStore(store);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.StoreId)
            {
                return BadRequest();
            }

            try
            {
                storeRepository.UpdateStore(store);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound("No Record Found with this Id...");

            }
            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            storeRepository.DeleteStore(id);
            return Ok("Store Deleted");
        }


    }
}