using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class CrewDTO
    {
        public int Id { get; set; }
        public int Pilot { get; set; }
        public ICollection<FlightDTO> FlightAttendantsList { get; set; }
    }
}

