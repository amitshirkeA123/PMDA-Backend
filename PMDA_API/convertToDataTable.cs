
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using System.Data;


namespace PMDA_API
{
    public static class convertToDataTable
    {
        public async static Task<DataTable> ConvertToDataTable(List<Dictionary<string, object>> sortedRows, List<string> MasterColumns)
        {
            var dataTable = new DataTable();
            if (sortedRows == null || sortedRows.Count == 0)
                return dataTable;
            List<string> lstColCheckforEmitter = new List<string>();
            List<string> lstColCheckforThreat = new List<string>();
            foreach (var key in MasterColumns)
            {
              
                #region Adding Columns In DataTable
                Type DataType = typeof(string);
                if (Common.IntDataTypes.Contains(key) || key.StartsWith(Common.Emitter) && Common.IntTypeEmitterSuffix.Any(suffix => key.EndsWith(suffix)) || key.StartsWith(Common.Threat) && Common.IntTypeEmitterSuffix.Any(suffix => key.EndsWith(suffix)))
                {
                    DataType = typeof(int);
                    dataTable.Columns.Add(key, DataType);
                    continue;
                }
                else if (Common.DoubleDataTypes.Contains(key) || key.StartsWith(Common.Threat) && Common.DobuleTypeForThreat.Any(suffix => key.EndsWith(suffix)))
                {
                    DataType = typeof(double);
                    dataTable.Columns.Add(key, DataType);
                    continue;
                }
                else if (key == "UTC_Time" || key == "Time")
                {
                    DataType = typeof(TimeSpan);
                    dataTable.Columns.Add(key, DataType);
                    continue;
                }
                else if (key== "MilliSecond")
                {
                    DataType = typeof(long);//in db using bigint
                    dataTable.Columns.Add(key, DataType);
                    continue;
                }
                else
                {
                    DataType = typeof(string);
                    dataTable.Columns.Add(key, DataType);
                    continue;
                }
                #endregion
            }
            List<object> test = new List<object>();
            #region Adding Csv File Data To Datatable
            int Hour = 0;
            List<int> TimeNotContais = new List<int>();
            foreach (var row in sortedRows)
            {
                var dataRow = dataTable.NewRow();
                foreach (var kvp in row)
                {

                    #region Commented Code Test For If Data Type if we want to change for that
                    dynamic ParseValue = 0;
                    string Column_Value = string.Empty;
                    if (Common.IntDataTypes.Contains(kvp.Key) || Common.IntTypeEmitterSuffix.Any(suffix => kvp.Key.EndsWith(suffix)) || kvp.Key.StartsWith(Common.Threat) && Common.IntTypeEmitterSuffix.Any(suffix => kvp.Key.EndsWith(suffix)))
                    {
                        Column_Value = kvp.Value.ToString();
                        int result = float.TryParse(Column_Value, out float parsedValue) ? (int)parsedValue : 0;
                        dataRow[kvp.Key] = result;
                        continue;
                      
                    }
                    else if (kvp.Key == "UTC_Time")
                    {
                        Column_Value = kvp.Value.ToString();
                        string utcTime = Common.ConvertToTimeSpan(Column_Value);
                        TimeSpan timespan = new TimeSpan();
                        timespan = TimeSpan.Parse(utcTime.Trim());
                        dataRow[kvp.Key] = timespan;

                        #region Converting Time Into Milliseconds column
                        long millisecondsTime= TimeConversion.ConvertTimeToMilliseconds(utcTime);
                        dataRow["MilliSecond"] = millisecondsTime;
                        #endregion

                        string time = "";
                        string timeval = "";
                        string Timedata = Common.ConvertToTimeSpan(Column_Value);
                        DateTime datetime = Convert.ToDateTime(Timedata);

                        string[] TimeParets = Column_Value.Split(':');


                        if (TimeParets.Length > 0)
                        {
                            int hours = int.Parse(TimeParets[0]);
                            int Min = int.Parse(TimeParets[1]);
                            int Sec = int.Parse(TimeParets[2]);
                            int MiliSec = int.Parse(TimeParets[3]);

                            if (Min == 0 && Sec == 0)
                                if (!TimeNotContais.Contains(hours))
                                    Hour++;

                            string UpdatedTime = Hour + ":" + Min + ":" + Sec + ":" + MiliSec;

                            string ResultTime = Common.ConvertToTimeSpan(UpdatedTime);
                            TimeSpan tm = new TimeSpan();
                            tm = TimeSpan.Parse(ResultTime.Trim());
                            dataRow["Time"] = tm;
                            TimeNotContais.Add(hours);
                        }
                        continue;
                    }
                    //else if (Common.DoubleDataTypes.Contains(kvp.Key))
                    else if (Common.DoubleDataTypes.Contains(kvp.Key) || kvp.Key.StartsWith(Common.Threat) && Common.DobuleTypeForThreat.Any(suffix => kvp.Key.EndsWith(suffix)))
                    {
                        Column_Value = kvp.Value.ToString();
                        ParseValue = (Column_Value != "") ? double.Parse(Column_Value.Trim()) : null;
                        dataRow[kvp.Key] = ParseValue ?? DBNull.Value;
                        continue;
                    }
                    else
                    {
                        dataRow[kvp.Key] = kvp.Value ?? DBNull.Value;
                        test.Add(kvp);
                    }
                    #endregion
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
            #endregion
        }


    }
}