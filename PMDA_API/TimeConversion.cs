using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PMDA_API;
using PMDA_API.Models;
using System;
using System.Linq;
using System.Reflection;

public static class TimeConversion
{
    public static long ConvertToMilliseconds(string time)
    {
        // Split the input time into hours, minutes, seconds, and milliseconds
        var timeParts = time.Split(':');
        var hours = int.Parse(timeParts[0]);
        var minutes = int.Parse(timeParts[1]);
        var secondsAndMilliseconds = timeParts[2].Split('.');
        var seconds = int.Parse(secondsAndMilliseconds[0]);
        var milliseconds = int.Parse(secondsAndMilliseconds[1].PadRight(3, '0')); // Ensure 3 digits for milliseconds

        // Calculate milliseconds for each component
        long totalMilliseconds = (hours * 3600 * 1000) + (minutes * 60 * 1000) + (seconds * 1000) + milliseconds;

        return totalMilliseconds;
    }


    public static List<MasterPMDARecords> FilterRecords(List<MasterPMDARecords> masterData)
    {
        var SortedData = masterData.OrderBy(a => a.UTC_Time).ToList();
        List<MasterPMDARecords> result = new List<MasterPMDARecords>();
        List<int> TrackId = new List<int>();
        List<TimeSpan> NoMatchableTime = new List<TimeSpan>();
        List<MasterPMDARecords> lstCurrentRecord = new List<MasterPMDARecords>();
        List<int> TimeCheck = new List<int>();
        for (int i = 0; i < SortedData.Count - 1; i++)
        {
            var currentRecord = SortedData[i];
            var nextRecord = SortedData[i + 1];

            if (NoMatchableTime.Contains(currentRecord.UTC_Time))
            {
                if (currentRecord.UTC_Time == nextRecord.UTC_Time)
                    continue;
                currentRecord=lstCurrentRecord[lstCurrentRecord.Count - 1];
            }
                

            if (currentRecord.UTC_Time == nextRecord.UTC_Time)
            {
                if (lstCurrentRecord.Count == 0)
                    lstCurrentRecord.Add(currentRecord);

                var sortedResult = SortedData.Where(a => a.UTC_Time == currentRecord.UTC_Time).ToList();
                if (!NoMatchableTime.Contains(currentRecord.UTC_Time))
                    foreach (var item in sortedResult)
                    {
                        if (!TrackId.Contains(item.Track_Id))
                            result.Add(item);

                        TrackId.Add(item.Track_Id);
                    }
                continue;
            }

            int currentMilliseconds = currentRecord.UTC_Time.Milliseconds;
            int nextMilliseconds = nextRecord.UTC_Time.Milliseconds;

            if (currentMilliseconds==097 || nextMilliseconds==097)
            {
                int tttt = 0;
            }

            bool IsChanged=IsTimeChanged(currentRecord, nextRecord, TimeCheck);
            if (IsChanged)
            {
                lstCurrentRecord.Clear();
                lstCurrentRecord.Add(nextRecord);
                continue;
            }

            TrackId.Clear();

            int sum = 250;
            bool IsNearestValue = IsNearestToSumOrValue(currentMilliseconds, sum, nextMilliseconds);
            if (IsNearestValue)
            {
                result.Add(nextRecord);
                TrackId.Add(nextRecord.Track_Id);
                lstCurrentRecord.Clear();
            }
            else
            {
                NoMatchableTime.Add(nextRecord.UTC_Time);
            }
        }

        return result;
    }
  

    public static bool IsNearestToSumOrValue(int value1, int sum, int value2)
    {
        try
        {
            bool IsNearest = false;
            int distanceToSum = Math.Abs(value1 - sum);
            int distanceToValue2 = Math.Abs(value1 - value2);
            return IsNearest = (distanceToValue2 >= sum - 50 && distanceToValue2 <= sum) ? true : false;
        }
        catch (Exception)
        {
            throw;
        }
      
    }

    public static bool IsTimeChanged(MasterPMDARecords currentRecord, MasterPMDARecords nextRecord, List<int> timecheck)
    {
        bool IsChanged = false;
        try
        {
            int hrs=currentRecord.UTC_Time.Hours;
            int min=currentRecord.UTC_Time.Minutes;
            int sec=currentRecord.UTC_Time.Seconds;
            int ms=currentRecord.UTC_Time.Milliseconds;
            int totaltime = int.Parse(hrs.ToString() + min.ToString() + sec.ToString());

            int nexthrs = nextRecord.UTC_Time.Hours;
            int nextmin = nextRecord.UTC_Time.Minutes;
            int nextsec = nextRecord.UTC_Time.Seconds;
            int nextms = nextRecord.UTC_Time.Milliseconds;
            int nexttotaltime = int.Parse(nexthrs.ToString() + nextmin.ToString() + nextsec.ToString());

            if (timecheck.Count == 0) timecheck.AddRange(new[] { totaltime, nexttotaltime });


            if (!timecheck.Contains(totaltime))
            {
                timecheck.Add(totaltime);
                return true;
            }

            if (!timecheck.Contains(nexttotaltime))
            {
                timecheck.Add(nexttotaltime);
                return true;
            }

            timecheck.Add(totaltime);
            timecheck.Add(nexttotaltime);
        }
        catch (Exception)
        {
            throw;
        }
        return IsChanged;
    }

    public static long ConvertTimeToMilliseconds(string time)
    {
        // Parse the time string into DateTime object
        DateTime parsedTime = DateTime.ParseExact(time, "HH:mm:ss.fff", null);

        // Create a DateTime object for midnight (00:00:00.000)
        DateTime midnight = DateTime.ParseExact("00:00:00.000", "HH:mm:ss.fff", null);

        // Calculate the difference in milliseconds from midnight
        long milliseconds = (long)(parsedTime - midnight).TotalMilliseconds;

        return milliseconds;
    }

    public static List<MasterPMDARecords> FilterData(List<MasterPMDARecords> masterData)
    {
        List<MasterPMDARecords> filteredRecords = new List<MasterPMDARecords>();

        long? previousMatchTime = null;
        List<MasterPMDARecords> currentGroup = null;

        for (int i = 0; i < masterData.Count; i++)
        {
            if (previousMatchTime == null || masterData[i].MilliSecond != previousMatchTime)
            {
                if (currentGroup != null && currentGroup.Count > 0)
                {
                    if (i < masterData.Count)
                    {
                        long timeDifference = masterData[i].MilliSecond - currentGroup[0].MilliSecond;

                        if (timeDifference >= Common.MinTimeDiff && timeDifference <= Common.MaxTimeDiff)
                        {
                            filteredRecords.AddRange(currentGroup);
                            currentGroup = new List<MasterPMDARecords> { masterData[i] };
                            previousMatchTime = masterData[i].MilliSecond;
                        }
                    }
                }
                else
                {
                    currentGroup = new List<MasterPMDARecords> { masterData[i] };
                    previousMatchTime = masterData[i].MilliSecond;
                }
            }
            else
            {
                currentGroup.Add(masterData[i]);
            }
        }

        return filteredRecords;
    }

    public static async Task<List<MasterPMDARecords>> FilterDataV2(List<MasterPMDARecords> masterData)
    {
        try
        {
            int milliseconds = 200;
            long? TimeDiffre = null;
            List<MasterPMDARecords> filteredRecords = new List<MasterPMDARecords>();
            List<long> lstMilliSecond = new List<long>();

            string StartUTC_Time = masterData[0].UTC_Time.ToString();
            string EndUTC_Time = masterData[masterData.Count-1].UTC_Time.ToString();
            TimeSpan StartTime = TimeSpan.Parse(StartUTC_Time);
            TimeSpan EndTime = TimeSpan.Parse(EndUTC_Time);
            TimeSpan TotalMissionTime = EndTime - StartTime;
            long _Milliseconds = (long)TotalMissionTime.TotalMilliseconds / milliseconds;

            foreach (var item in masterData)
            {
                lstMilliSecond.Add(item.MilliSecond);
                if (_Milliseconds == lstMilliSecond.Count)
                    break;

                if (filteredRecords != null && filteredRecords.Count > 0)
                {
                    if (_Milliseconds == lstMilliSecond.Count)
                        break;

                    var closestRecord = masterData
                    .Where(r => r.MilliSecond <= (long)TimeDiffre)  // Filter for records with milliseconds <= targetTime
                    .OrderByDescending(r => r.MilliSecond)    // Order by milliseconds descending (largest less value)
                    .FirstOrDefault();
                    filteredRecords.Add(closestRecord);
                    TimeDiffre += milliseconds;
                }
                else
                {
                    filteredRecords.Add(masterData[0]);
                    TimeDiffre = milliseconds + masterData[0].MilliSecond;
                }
            }

            return filteredRecords;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static List<MasterPMDARecords> FilterDataV3(List<MasterPMDARecords> masterData,int RefreshRate)
    {
        int milliseconds = 300;
        long? TimeDiffre = null;
        List<MasterPMDARecords> filteredRecords = new List<MasterPMDARecords>();
        long? previousMatchTime = null;
        List<MasterPMDARecords> currentGroup = null;

        for (int i = 0; i < masterData.Count; i++)
        {
            long _miliseconds = masterData[i].MilliSecond;
            if (filteredRecords != null && filteredRecords.Count > 0)
            {
                var closestRecord = masterData
                .Where(r => r.MilliSecond <= (long)TimeDiffre)  // Filter for records with milliseconds <= targetTime
                .OrderByDescending(r => r.MilliSecond)    // Order by milliseconds descending (largest less value)
                .FirstOrDefault();
                filteredRecords.Add(closestRecord);
                TimeDiffre += RefreshRate;
            }
            else
            {
                filteredRecords.Add(masterData[i]);
                TimeDiffre = RefreshRate + masterData[i].MilliSecond;
            }
        }
        return filteredRecords;
    }


    // ✅ **Ensure Time is in HH:MM:SS:FFF Format**
    public static object GetPropertyValue(object obj, string propName)
    {
        var property = obj.GetType().GetProperty(propName);
        var value = property?.GetValue(obj, null);

        if (value is TimeSpan timeSpanValue)
        {
            return timeSpanValue.ToString(@"hh\:mm\:ss\:fff"); // Converts TimeSpan to HH:MM:SS:FFF format
        }
        if (value is DateTime dateTimeValue)
        {
            return dateTimeValue.ToUniversalTime().ToString("HH:mm:ss:fff"); // Converts DateTime to HH:MM:SS:FFF
        }

        return value;
    }
}
