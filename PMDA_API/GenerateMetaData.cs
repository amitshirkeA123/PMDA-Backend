using PMDA_API.Models;

namespace PMDA_API
{
    public static class GenerateMetaData
    {
        public static async Task<List<emitters>> SetMetaData(List<Dictionary<string, object>> EtrData, List<string> EmitterData)
        {
            List<emitters> lstEmitter = new List<emitters>();
            try
			{
                metadata objMetaData = new metadata();
                for (int i = 0; i < EtrData.Count; i++)
                {
                    emitters objemiter = new emitters();
                    string EmiterId = EtrData[i]["EmitterId"].ToString();
                    if (!EmitterData.Contains(EmiterId))
                    {
                        EmitterData.Add(EmiterId);
                        objemiter.EmitterId = EmiterId;
                        lstEmitter.Add(objemiter);
                    }
                }
                objMetaData.description = "PMDA_Testing";
                objMetaData.total_emitters = EmitterData.Count;
            }
			catch (Exception)
			{
				throw;
			}
            return lstEmitter;
        }

        public static async Task<HashSet<string>> SetThreatMetaData(List<Dictionary<string, object>> threatData)
        {
            HashSet<string> uniqueThreats = new HashSet<string>();
            try
            {
                List<Threats> uniqueThreatObjects = new List<Threats>();
                foreach (var row in threatData)
                {
                    Threats threat = new Threats();

                    // Loop through the threat keys (Threat_1_ThreatName to Threat_16_ThreatName)
                    for (int i = 1; i <= 16; i++)
                    {
                        string threatKey = $"Threat_{i}_ThreatName";

                        // Check if the row contains this threat column
                        if (row.ContainsKey(threatKey))
                        {
                            string threatName = row[threatKey]?.ToString();

                            // If the threat is unique, add it to the HashSet and the Threats object
                            if (!string.IsNullOrEmpty(threatName) && !uniqueThreats.Contains(threatName))
                            {
                                uniqueThreats.Add(threatName);

                                // Dynamically assign the threat name to the Threats object
                                typeof(Threats).GetProperty(threatKey)?.SetValue(threat, threatName);
                            }
                        }
                    }
                    if (threat != null)
                    {
                        uniqueThreatObjects.Add(threat);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return uniqueThreats;
        }

        public static async Task<TimeSpan> SetTotalMissionTime(List<Dictionary<string,object>> sortedDAta)
        {
            TimeSpan TotalMissionTime;
            try
            {
                string StartUTC_Time = sortedDAta[0]["UTC_Time"].ToString();
                string EndUTC_Time = sortedDAta[sortedDAta.Count - 1]["UTC_Time"].ToString();
                DateTime StartTime = DateTime.ParseExact(StartUTC_Time, "HH:mm:ss:fff", null);
                DateTime EndTime = DateTime.ParseExact(EndUTC_Time, "HH:mm:ss:fff", null);
                TotalMissionTime = EndTime - StartTime;
            }
            catch (Exception)
            {
                throw;
            }
            return TotalMissionTime;
        }
    }
}
