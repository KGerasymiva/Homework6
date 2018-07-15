using System.Collections.Generic;
using BL.Service;
using DAL.UnitOfWork;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //   [Route("api/PlaneType")]
    public class PlaneTypeController : Controller
    {
        private IServicePlaneType servicePlaneType;

        public PlaneTypeController(IServicePlaneType servicePlaneType)
        {
            this.servicePlaneType = servicePlaneType;
        }

        // GET: api/PlaneTypeDTO
        [HttpGet]
        public IEnumerable<PlaneTypeDTO> Get()
        {
            return servicePlaneType.GetPlaneTypes();
        }

        // GET: api/PlaneTypeDTO/5
        [HttpGet("{id}")]
        public PlaneTypeDTO Get(int id)
        {
            return servicePlaneType.GetPlaneType(id);
        }

        // POST: api/PlaneTypeDTO
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PlaneTypeDTO/5
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
