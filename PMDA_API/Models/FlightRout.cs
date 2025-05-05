namespace PMDA_API.Models
{
    public class FlightRoutes
    {
        public TimeSpan UTC { get; set; }  
        public double Time { get; set; }  
        //public long Time { get; set; }  
        public decimal Lat { get;set; }   
        public decimal Long { get;set; }
        public decimal TrueHeading_pi_rad { get; set; }
        public decimal PitchAngle_pi_rad { get; set; }
        public decimal RollAngle_pi_rad { get; set; }
        public int Altitude_m { get; set; }

    }

    public class FlightRouteContainer
    {
        public List<FlightRoutes> FlightRoutes { get; set; }
    }
}
