

namespace PMDA_API.Models
{
    public class FlightData
    {
        public metadata metadata { get; set; }
        public List<MasterPMDARecords> PMDAData { get; set; }
    }



    public class metadata
    {
        public string description { get; set; }
        public int total_emitters { get; set; }
        public int TotalThreats { get; set; }
        public string[] fields { get; set; }
        public flight_start flight_start { get; set; }
        public flight_end flight_end { get; set; }
        public List<emitters> emitters { get; set; }
        // public List<ThreatData> Threatdata { get; set; }
        public string[] ThreatData { get; set; }
        public TimeSpan MissionTime { get; set; }
    }

    public class Threats
    {
        public string Threat_1_ThreatName { get; set; }
        public string Threat_2_ThreatName { get; set; }
        public string Threat_3_ThreatName { get; set; }
        public string Threat_4_ThreatName { get; set; }
        public string Threat_5_ThreatName { get; set; }
        public string Threat_6_ThreatName { get; set; }
        public string Threat_7_ThreatName { get; set; }
        public string Threat_8_ThreatName { get; set; }
        public string Threat_9_ThreatName { get; set; }
        public string Threat_10_ThreatName { get; set; }
        public string Threat_11_ThreatName { get; set; }
        public string Threat_12_ThreatName { get; set; }
        public string Threat_13_ThreatName { get; set; }
        public string Threat_14_ThreatName { get; set; }
        public string Threat_15_ThreatName { get; set; }
        public string Threat_16_ThreatName { get; set; }
    }
    public class flight_start
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
    public class flight_end
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
    public class emitters
    {
        public string EmitterId { get; set; }///emitter id 
        //public double EmitterRange { get; set; }
        //public double Frequency { get; set; }

        //public double? Latitude { get; set; }
        //public double? Longitude { get; set; }
        //public string Strength { get; set; }
        //public long DetectionStart { get; set; }
        //public long DetectionEnd { get; set; }
    }
   
}
