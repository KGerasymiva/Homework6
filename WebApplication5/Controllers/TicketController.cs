using System;
using System.Collections.Generic;
using BL;
using BL.Service;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PL.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private IServiceTicket _serviceTicket;

        public TicketController(IServiceTicket serviceTicket)
        {
            this._serviceTicket = serviceTicket;
        }

        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<TicketDTO> Get()
        {

            return _serviceTicket.GetTickets();
        }

        // GET: api/TicketDTO/5
        [HttpGet("{id}")]
        public TicketDTO Get(int id)
        {
            return _serviceTicket.GetTicket(id);
        }


        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] TicketPL ticket)
        {
            _serviceTicket.PostTicket(ticket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TicketPL ticket)
        {
            ticket.Id = id;
            _serviceTicket.PutTicket(ticket);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceTicket.DeleteTicket(id);
        }

        private class Ticket
        {
            public int FlightId { get; set; }
            public decimal Price { get; set; }
            public int Id { get; set; }
        }
    }
}
