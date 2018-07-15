using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Models
{
    public class Flight : Entity
    {
        [RegularExpression(@"^[A-Z]{2}\d{6}$")]
        public string Number { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        [DataType(DataType.Date)]
        public string DeparturingTime { get; set; }
        [DataType(DataType.Date)]
        public string ArrivingTime { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
