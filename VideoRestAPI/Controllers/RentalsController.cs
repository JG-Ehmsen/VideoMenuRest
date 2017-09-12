using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BLL.BO;
using System;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RentalsController : Controller
    {
        BLLFacade facade = BLLFacade.GetInstance();

        // GET: api/Rentals
        [HttpGet]
        public IEnumerable<RentalBO> Get()
        {
            return facade.RentalService.GetAll();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}", Name = "Get")]
        public RentalBO Get(int id)
        {
            return facade.RentalService.Get(id);
        }
        
        // POST: api/Rentals
        [HttpPost]
        public IActionResult Post([FromBody]RentalBO rental)
        {
            if(!TryValidateModel(rental))
            {
                return BadRequest(ModelState.IsValid);
            }

            return Ok(facade.RentalService.Add(rental));
        }
        
        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RentalBO rental)
        {
            if (id != rental.Id)
            {
                return BadRequest("Path ID does not match video ID in JSON object.");
            }
            try
            {
                return Ok(facade.RentalService.Update(rental));
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.RentalService.Delete(id);
        }
    }
}
