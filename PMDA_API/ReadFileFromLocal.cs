
using CsvHelper;
using System.Data;
using System.Globalization;


namespace PMDA_API
{
    public static class ReadFileFromLocal
    {
        public async static Task<DataTable> ReadFile(List<IFormFile> files)
        {
            #region Reading And Merging File In List
            List<String> lstMasterColumns = new List<string>();
            lstMasterColumns.Add("UTC_Time");
            var rowLookup = new Dictionary<string, Dictionary<string, object>>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    using (var reader = new StreamReader(stream))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var fileData = csv.GetRecords<dynamic>();
                        List<string>lstEmitters=new List<string>();
                        foreach (var record in fileData)
                        {
                            var recordDict = (IDictionary<string, object>)record;
                            string utcDateTime = recordDict["UTC_Time"]?.ToString();
                            string utcTime = Common.ConvertToTimeSpan(utcDateTime);


                            //TimeSpan time = TimeSpan.Parse(utcDateTime); // Convert string to DateTime
                            //string utcTime = tm.ToString("HH:mm:ss:fff"); // Extr
                            if (string.IsNullOrEmpty(utcTime))
                                throw new Exception("UTC_TIME column is missing or empty in the file.");
                            if (!rowLookup.ContainsKey(utcTime))
                            {
                                // Add a new row if UTC_TIME is not found
                                rowLookup[utcTime] = new Dictionary<string, object>
                                {
                                    { "UTC_Time", utcTime }
                                };
                            }
                            // Update the existing row for this UTC_TIME
                            var existingRow = rowLookup[utcTime];
                            foreach (var kvp in recordDict)
                            {
                                if (!existingRow.ContainsKey(kvp.Key))
                                {
                                    if (!lstMasterColumns.Contains(kvp.Key))
                                    {
                                        lstMasterColumns.Add(kvp.Key);
                                    }
                                    existingRow[kvp.Key] = kvp.Value;
                                }
                                else if (kvp.Value != null)
                                {
                                    if (kvp.Key== "UTC_Time")
                                    {
                                        existingRow[kvp.Key] = utcTime;
                                    }
                                    else
                                    {
                                        existingRow[kvp.Key] = kvp.Value;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            var sortedRowss = new List<Dictionary<string, object>>(rowLookup.Values);
            sortedRowss.Sort((x, y) =>
            {
                var xTime = DateTime.Parse(x["UTC_Time"].ToString());
                var yTime = DateTime.Parse(y["UTC_Time"].ToString());
                return xTime.CompareTo(yTime);
            });

            DataTable Dt_ResultSortedRow = await Task.Run(() =>
            {
                return convertToDataTable.ConvertToDataTable(sortedRowss, lstMasterColumns);
            });

            //string json = JsonConvert.SerializeObject(Dt_ResultSortedRow, Formatting.Indented);
            return Dt_ResultSortedRow;
            #endregion
        }
    }
}
