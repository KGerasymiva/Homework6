namespace DAL.Models
{
    public class PlaneType : Entity
    {
        public string Model { get; set; }
        public int Seats { get; set; }
        public double Payload { get; set; }
    }
}
