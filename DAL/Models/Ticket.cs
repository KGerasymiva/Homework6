using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Ticket : Entity
    {
        public decimal Price { get; set; }
        public int FlightForeignKey { get; set; }
        public Flight Flight { get; set; }
    }
}
