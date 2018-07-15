using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Departure : Entity
    {
        [ForeignKey("Flight")]
        public int Flight { get; set; }
        [DataType(DataType.Date)]
        public string DepartingTime { get; set; }
        [ForeignKey("Crew")]
        public int Crew { get; set; }
        [ForeignKey("Plane")]
        public int Plane { get; set; }
    }
}
