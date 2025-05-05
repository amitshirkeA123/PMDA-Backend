namespace PMDA_API.Models
{


    public class UIResponse
    {
      public HeaderValues Data { get; set; }
    }

    public class Headers
    {
        public int Time { get; set; }
        public List<string> Nav { get; set; }
        public List<string> Etr { get; set; }
        public List<string> Tht { get; set; }
        public List<string> Rdr { get; set; }
    }

    public class HeaderValues
    {
        //public TimeSpan UTC_Time { get; set; }
        public List<object> nav { get; set; }
        public List<List<object>>? etr { get; set; } = new List<List<object>>();
        public List<object> tht { get; set; }
        public List<object> rdr { get; set; }
    }

    public class APIResponse
    {
        public Headers headers { get; set; }
        public Dictionary<TimeSpan, List<object>> uiData { get; set; }
    }
  
}
