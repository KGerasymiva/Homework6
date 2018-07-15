using System.Collections.Generic;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //   [Route("api/CrewDTO")]
    public class CrewController : Controller
    {
        private IUnitOfWork unitOfWork;
        public CrewController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: api/CrewDTO
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CrewDTO/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/CrewDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/CrewDTO/5
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
