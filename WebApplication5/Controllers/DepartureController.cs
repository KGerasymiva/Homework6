using System.Collections.Generic;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //   [Route("api/DepartureDTO")]
    public class DepartureController : Controller
    {
        private IUnitOfWork unitOfWork;
        public DepartureController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/DepartureDTO
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DepartureDTO/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/DepartureDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/DepartureDTO/5
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
