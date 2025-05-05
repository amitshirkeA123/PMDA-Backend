using CsvHelper.Configuration;
using CsvHelper;
using System.Formats.Tar;
using System.Globalization;
using System.Data;
using System.Collections.Concurrent;

namespace MasterData2
{
    public static class CsvToDic
    {
        public static List<Dictionary<string, object>> Convert(string FilePath)
        {
			try
			{
                var records = new List<Dictionary<string, object>>();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null, // Prevent missing field errors
                    IgnoreBlankLines = true   // Skip blank lines
                };

                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, config))
                {
                    if (csv.Read()) // Ensure file is not empty
                    {
                        csv.ReadHeader(); // Read the header first

                        while (csv.Read()) // Read each row
                        {
                            var record = new Dictionary<string, object>();

                            foreach (var header in csv.Context.Reader.HeaderRecord)
                            {
                                record[header] = csv.GetField(header);
                            }

                            records.Add(record);
                        }
                    }
                }
                return records;
            }
			catch (Exception)
			{
				throw;
			}
        }


        public static List<Dictionary<string, object>> MergeDictionaries(
            List<Dictionary<string, object>> etrData,
            List<Dictionary<string, object>> navData,
            List<Dictionary<string, object>> threatData,
            List<Dictionary<string, object>> radarData)
        {
            var mergedResult = new List<Dictionary<string, object>>(etrData.Count);
            var navMap = BuildFastLookup(navData);
            var threatMap = BuildFastLookup(threatData);
            var radarMap = BuildFastLookup(radarData);

            // 🚀 Super-Fast Parallelized Merging with Partitioning
            var mergedData = etrData
                .AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                .Select(etr =>
                {
                    var mergedRow = new Dictionary<string, object>(etr);
                    TimeSpan etrTime = ParseTime(etr["UTC_Time"].ToString());
                    MergeClosestData(navMap, etrTime, mergedRow);
                    MergeClosestData(threatMap, etrTime, mergedRow);
                    MergeClosestData(radarMap, etrTime, mergedRow);

                    return mergedRow;
                }).ToList();

            return mergedData;
        }


        public static void MergeClosestData(Dictionary<TimeSpan, Dictionary<string, object>> dataMap, TimeSpan targetTime, Dictionary<string, object> mergedRow)
        {
            if (dataMap.Count == 0) return;

            if (dataMap.TryGetValue(targetTime, out var exactMatch))
            {
                ApplyData(exactMatch, mergedRow);
                return;
            }

            var nearestTime = dataMap.Keys.OrderBy(t => Math.Abs((t - targetTime).Ticks)).FirstOrDefault();
            if (nearestTime != default)
                ApplyData(dataMap[nearestTime], mergedRow);
        }

        public static void ApplyData(Dictionary<string, object> sourceData, Dictionary<string, object> targetRow)
        {
            foreach (var kv in sourceData)
            {
                if (!targetRow.ContainsKey(kv.Key))
                    targetRow[kv.Key] = kv.Value;
            }
        }

        public static TimeSpan ParseTime(string timeStr)
        {
            return TimeSpan.ParseExact(timeStr.PadRight(12, '0'), "hh\\:mm\\:ss\\:fff", CultureInfo.InvariantCulture);
        }
        

        public static Dictionary<TimeSpan, Dictionary<string, object>> BuildFastLookup(List<Dictionary<string, object>> dataList)
        {
            var lookup = new Dictionary<TimeSpan, Dictionary<string, object>>(dataList.Count);
            foreach (var data in dataList)
            {
                var time = ParseTime(data["UTC_Time"].ToString());
                lookup[time] = data;
            }
            return lookup;
        }
       

        public static DataTable ConvertToDataTable(List<Dictionary<string, object>> data)
        {
            DataTable dt = new DataTable();
            try
            {
                if (data.Count == 0)
                    return dt;

                foreach (var key in data.First().Keys)
                {
                    dt.Columns.Add(key, typeof(string));
                }

                foreach (var dict in data)
                {
                    DataRow row = dt.NewRow();
                    foreach (var kvp in dict)
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                    dt.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
