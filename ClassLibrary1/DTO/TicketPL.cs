using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TicketPL
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int FlightForeignKey { get; set; }
    }
}
