using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentaBoatApi.Data;
using RentaBoatApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentaBoatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {
        private readonly RentApiDbContext dbContext;

        public BoatsController(RentApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<BoatController>
        [HttpGet]
        public async Task<IActionResult> GetAllBoats()
        {
            return Ok(await dbContext.Boats.ToListAsync());
        }









        // GET api/<BoatController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoatController>
        [HttpPost]
        public async Task<IActionResult> InsertBoat(InsertBoatModel ibm)
        {
            var boat = new Boat()
            {
                Producer = ibm.Producer,
                Model = ibm.Model,
                PersonsMax = ibm.PersonsMax,
                ProductionYear = ibm.ProductionYear,
                Description = ibm.Description
            };

            await dbContext.Boats.AddAsync(boat);
            await dbContext.SaveChangesAsync();
            return Ok(boat);
        }

        // PUT api/<BoatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
