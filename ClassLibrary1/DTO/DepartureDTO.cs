using System;

namespace DTO
{
    public class DepartureDTO
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string DepartingTime { get; set; }
        public int Crew { get; set; }
        public int Plane { get; set; }
    }
}
