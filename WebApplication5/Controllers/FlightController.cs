using System.Collections.Generic;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //    [Route("api/FlightDTO")]
    public class FlightController : Controller
    {
        private IUnitOfWork unitOfWork;
        public FlightController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/FlightDTO
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightDTO/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/FlightDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/FlightDTO/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
