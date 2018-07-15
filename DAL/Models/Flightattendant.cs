using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Flightattendant : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public string BirthDay { get; set; }
        public int CrewForeignKey { get; set; }
        public Crew Crew { get; set; }
    }
}
