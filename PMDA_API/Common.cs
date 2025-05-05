using MasterData2;
using Microsoft.Data.SqlClient;
using PMDA_API.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Data;
using System.IO.Compression;
using System.Reflection;

namespace PMDA_API
{
    public static class Common
    {
        public static int MinTimeDiff = 200;
       // public static int MaxTimeDiff = 250;
        public static int MaxTimeDiff = 250;

        #region ThreatHeaders
        public static List<string> ThreatHeaders = new List<string>
        {
             "ThreatCount",
             "Threat_1_Threat_Presence",
             "Threat_1_ThreatSymbolCode",
             "Threat_1_ThreatAltSymbolcode",
             "Threat_1_ThreatName",
             "Threat_1_ThreatSymFGColour",
             "Threat_1_ThreatSymBGColour",
             "Threat_1_CircleAttribute",
             "Threat_1_SquareAttribute",
             "Threat_1_MoustacheAttribute",
             "Threat_1_DiamondAttribure",
             "Threat_1_DisplayStatus",
             "Threat_1_BlinkStatus",
             "Threat_1_MDTStatus",
             "Threat_1_Azimuth",
             "Threat_1_ThreatRange",
             "Threat_2_Threat_Presence",
             "Threat_2_ThreatSymbolCode",
             "Threat_2_ThreatAltSymbolcode",
             "Threat_2_ThreatName",
             "Threat_2_ThreatSymFGColour",
             "Threat_2_ThreatSymBGColour",
             "Threat_2_CircleAttribute",
             "Threat_2_SquareAttribute",
             "Threat_2_MoustacheAttribute",
             "Threat_2_DiamondAttribure",
             "Threat_2_DisplayStatus",
             "Threat_2_BlinkStatus",
             "Threat_2_MDTStatus",
             "Threat_2_Azimuth",
             "Threat_2_ThreatRange",
             "Threat_3_Threat_Presence",
             "Threat_3_ThreatSymbolCode",
             "Threat_3_ThreatAltSymbolcode",
             "Threat_3_ThreatName",
             "Threat_3_ThreatSymFGColour",
             "Threat_3_ThreatSymBGColour",
             "Threat_3_CircleAttribute",
             "Threat_3_SquareAttribute",
             "Threat_3_MoustacheAttribute",
             "Threat_3_DiamondAttribure",
             "Threat_3_DisplayStatus",
             "Threat_3_BlinkStatus",
             "Threat_3_MDTStatus",
                "Threat_3_Azimuth",
             "Threat_3_ThreatRange",
             "Threat_4_Threat_Presence",
             "Threat_4_ThreatSymbolCode",
             "Threat_4_ThreatAltSymbolcode",
             "Threat_4_ThreatName",
             "Threat_4_ThreatSymFGColour",
             "Threat_4_ThreatSymBGColour",
             "Threat_4_CircleAttribute",
             "Threat_4_SquareAttribute",
             "Threat_4_MoustacheAttribute",
             "Threat_4_DiamondAttribure",
             "Threat_4_DisplayStatus",
             "Threat_4_BlinkStatus",
             "Threat_4_MDTStatus",
                "Threat_4_Azimuth",
             "Threat_4_ThreatRange",
             "Threat_5_Threat_Presence",
             "Threat_5_ThreatSymbolCode",
             "Threat_5_ThreatAltSymbolcode",
             "Threat_5_ThreatName",
             "Threat_5_ThreatSymFGColour",
             "Threat_5_ThreatSymBGColour",
             "Threat_5_CircleAttribute",
             "Threat_5_SquareAttribute",
             "Threat_5_MoustacheAttribute",
             "Threat_5_DiamondAttribure",
             "Threat_5_DisplayStatus",
             "Threat_5_BlinkStatus",
             "Threat_5_MDTStatus",
                "Threat_5_Azimuth",
             "Threat_5_ThreatRange",
             "Threat_6_Threat_Presence",
             "Threat_6_ThreatSymbolCode",
             "Threat_6_ThreatAltSymbolcode",
             "Threat_6_ThreatName",
             "Threat_6_ThreatSymFGColour",
             "Threat_6_ThreatSymBGColour",
             "Threat_6_CircleAttribute",
             "Threat_6_SquareAttribute",
             "Threat_6_MoustacheAttribute",
             "Threat_6_DiamondAttribure",
             "Threat_6_DisplayStatus",
             "Threat_6_BlinkStatus",
             "Threat_6_MDTStatus",
                "Threat_6_Azimuth",
             "Threat_6_ThreatRange",
             "Threat_7_Threat_Presence",
             "Threat_7_ThreatSymbolCode",
             "Threat_7_ThreatAltSymbolcode",
             "Threat_7_ThreatName",
             "Threat_7_ThreatSymFGColour",
             "Threat_7_ThreatSymBGColour",
             "Threat_7_CircleAttribute",
             "Threat_7_SquareAttribute",
             "Threat_7_MoustacheAttribute",
             "Threat_7_DiamondAttribure",
             "Threat_7_DisplayStatus",
             "Threat_7_BlinkStatus",
             "Threat_7_MDTStatus",
                "Threat_7_Azimuth",
             "Threat_7_ThreatRange",
             "Threat_8_Threat_Presence",
             "Threat_8_ThreatSymbolCode",
             "Threat_8_ThreatAltSymbolcode",
             "Threat_8_ThreatName",
             "Threat_8_ThreatSymFGColour",
             "Threat_8_ThreatSymBGColour",
             "Threat_8_CircleAttribute",
             "Threat_8_SquareAttribute",
             "Threat_8_MoustacheAttribute",
             "Threat_8_DiamondAttribure",
             "Threat_8_DisplayStatus",
             "Threat_8_BlinkStatus",
             "Threat_8_MDTStatus",
                "Threat_8_Azimuth",
             "Threat_8_ThreatRange",
             "Threat_9_Threat_Presence",
             "Threat_9_ThreatSymbolCode",
             "Threat_9_ThreatAltSymbolcode",
             "Threat_9_ThreatName",
             "Threat_9_ThreatSymFGColour",
             "Threat_9_ThreatSymBGColour",
             "Threat_9_CircleAttribute",
             "Threat_9_SquareAttribute",
             "Threat_9_MoustacheAttribute",
             "Threat_9_DiamondAttribure",
             "Threat_9_DisplayStatus",
             "Threat_9_BlinkStatus",
             "Threat_9_MDTStatus",
                "Threat_9_Azimuth",
             "Threat_9_ThreatRange",
             "Threat_10_Threat_Presence",
             "Threat_10_ThreatSymbolCode",
             "Threat_10_ThreatAltSymbolcode",
             "Threat_10_ThreatName",
             "Threat_10_ThreatSymFGColour",
             "Threat_10_ThreatSymBGColour",
             "Threat_10_CircleAttribute",
             "Threat_10_SquareAttribute",
             "Threat_10_MoustacheAttribute",
             "Threat_10_DiamondAttribure",
             "Threat_10_DisplayStatus",
             "Threat_10_BlinkStatus",
             "Threat_10_MDTStatus",
                "Threat_10_Azimuth",
             "Threat_10_ThreatRange",
             "Threat_11_Threat_Presence",
             "Threat_11_ThreatSymbolCode",
             "Threat_11_ThreatAltSymbolcode",
             "Threat_11_ThreatName",
             "Threat_11_ThreatSymFGColour",
             "Threat_11_ThreatSymBGColour",
             "Threat_11_CircleAttribute",
             "Threat_11_SquareAttribute",
             "Threat_11_MoustacheAttribute",
             "Threat_11_DiamondAttribure",
             "Threat_11_DisplayStatus",
             "Threat_11_BlinkStatus",
             "Threat_11_MDTStatus",
                "Threat_11_Azimuth",
             "Threat_11_ThreatRange",
             "Threat_12_Threat_Presence",
             "Threat_12_ThreatSymbolCode",
             "Threat_12_ThreatAltSymbolcode",
             "Threat_12_ThreatName",
             "Threat_12_ThreatSymFGColour",
             "Threat_12_ThreatSymBGColour",
             "Threat_12_CircleAttribute",
             "Threat_12_SquareAttribute",
             "Threat_12_MoustacheAttribute",
             "Threat_12_DiamondAttribure",
             "Threat_12_DisplayStatus",
             "Threat_12_BlinkStatus",
             "Threat_12_MDTStatus",
                "Threat_12_Azimuth",
             "Threat_12_ThreatRange",
             "Threat_13_Threat_Presence",
             "Threat_13_ThreatSymbolCode",
             "Threat_13_ThreatAltSymbolcode",
             "Threat_13_ThreatName",
             "Threat_13_ThreatSymFGColour",
             "Threat_13_ThreatSymBGColour",
             "Threat_13_CircleAttribute",
             "Threat_13_SquareAttribute",
             "Threat_13_MoustacheAttribute",
             "Threat_13_DiamondAttribure",
             "Threat_13_DisplayStatus",
             "Threat_13_BlinkStatus",
             "Threat_13_MDTStatus",
                "Threat_13_Azimuth",
             "Threat_13_ThreatRange",
             "Threat_14_Threat_Presence",
             "Threat_14_ThreatSymbolCode",
             "Threat_14_ThreatAltSymbolcode",
             "Threat_14_ThreatName",
             "Threat_14_ThreatSymFGColour",
             "Threat_14_ThreatSymBGColour",
             "Threat_14_CircleAttribute",
             "Threat_14_SquareAttribute",
             "Threat_14_MoustacheAttribute",
             "Threat_14_DiamondAttribure",
             "Threat_14_DisplayStatus",
             "Threat_14_BlinkStatus",
             "Threat_14_MDTStatus",
                "Threat_14_Azimuth",
             "Threat_14_ThreatRange",
             "Threat_15_Threat_Presence",
             "Threat_15_ThreatSymbolCode",
             "Threat_15_ThreatAltSymbolcode",
             "Threat_15_ThreatName",
             "Threat_15_ThreatSymFGColour",
             "Threat_15_ThreatSymBGColour",
             "Threat_15_CircleAttribute",
             "Threat_15_SquareAttribute",
             "Threat_15_MoustacheAttribute",
             "Threat_15_DiamondAttribure",
             "Threat_15_DisplayStatus",
             "Threat_15_BlinkStatus",
             "Threat_15_MDTStatus",
                "Threat_15_Azimuth",
             "Threat_15_ThreatRange",
             "Threat_16_Threat_Presence",
             "Threat_16_ThreatSymbolCode",
             "Threat_16_ThreatAltSymbolcode",
             "Threat_16_ThreatName",
             "Threat_16_ThreatSymFGColour",
             "Threat_16_ThreatSymBGColour",
             "Threat_16_CircleAttribute",
             "Threat_16_SquareAttribute",
             "Threat_16_MoustacheAttribute",
             "Threat_16_DiamondAttribure",
             "Threat_16_DisplayStatus",
             "Threat_16_BlinkStatus",
             "Threat_16_MDTStatus",
                "Threat_16_Azimuth",
             "Threat_16_ThreatRange"
            };

        #endregion
        #region EmitterHeaders
        public static List<string> EmitterHeaders = new List<string>()
        {
            "Track_Id",
            "HitCount",
            "SymbolCode",
            "Frequency",
            "PulseWidth",
            "Amplitude",
            "AOA",
            "DOA",
            "Lattitude",
            "Longitude",
            "TrueHeading",
            "Altitude_m",
            "RollAngle",
            "PitchRate",
            "YawRate",
            "Weaponid",
            "WeaponDescription",
            "EmitterId",
            "EmitterDescription",
            "ModeId",
            "ModeDescription",
            "EmitterRange",
            "PRI_1"
        };
        #endregion

        #region NavHeaders
        public static List<string> NavHeaders = new List<string>()
        {
            "UTC_Time",
            "INS_Pram_Valid",
            "Baro_Altitude_Valid",
            "Radio_HI_Valid",
            "GPS_Data_Valid",
            "Ac_On_GND_Status",
            "CMDS_Presence",
            "TrueHeading_pi_rad",
            "PitchAngle_pi_rad",
            "RollAngle_pi_rad",
            "PresentPosLatitude",
            "PresentPosLongitude",
            "XVelocity",
            "YVelocity",
            "ZVelocity",
            "PitchRate_pi_rad_s",
            "RollRate_pi_rad_s",
            "YawRate_pi_rad_s",
            "RadioHeight_m",
            "BaroAltitude",
            "GPS_Yday",
            "GPS_Hour",
            "GPS_Minute",
            "GPS_Seconds"
        };
        #endregion

        #region RadarHeaders
        public static List<string> RadarHeaders = new List<string>()
        {
            "RDR_Tx_Band",
            "RDR_Radar_Transmission",
            "RDR_Health_Status",
            "EraseSelect",
            "RDR_RadarMode",
            "RDR_MinorMode"
        };
        #endregion

        #region This Feilds Contains Int DataTypes
        public static List<string> IntDataTypes = new List<string>
        {
           "ThreatCount",
           "RadioHeight_m",
           "BaroAltitude",
           "GPS_Yday",
           "GPS_Hour",
           "GPS_Minute",
           "GPS_Seconds",
           "Track_Id",
           "HitCount",
           "SymbolCode",
           "Altitude_m",
           "EraseSelect",
        };
        #endregion

        #region This Feilds Contains Double DataTypes
        public static List<string> DoubleDataTypes = new List<string>
        {
            "TrueHeading_pi_rad",
            "PitchAngle_pi_rad",
            "RollAngle_pi_rad",
            "PresentPosLongitude",
            "PresentPosLatitude",
            "XVelocity",
            "YVelocity",
            "ZVelocity",
            "PitchRate_pi_rad_s",
            "RollRate_pi_rad_s",
            "YawRate_pi_rad_s",
            "Frequency",
            "PulseWidth",
            "Amplitude",
            "AOA",
            "DOA",
            "Latitude",
            "Longitude",
            "TrueHeading",
            "RollAngle",
            "PitchRate",
            "YawRate",
            "EmitterRange",
        };
        #endregion

        #region Threat Data Feilds
        public static string Threat = "Threat";
        public static string _Threat_Presence = "_Threat_Presence";
        public static string _Threat_symbol_code = "_ThreatSymbolCode";
        public static string _Threat_Alt_symbolcode = "_ThreatAltSymbolCode";
        public static string _Threat_sym_FG_colour = "_ThreatSymFGColour";
        public static string _Threatsym_BG_colour = "_ThreatSymBGColour";
        public static string _circle_Attribute = "_CircleAttribute";
        public static string _Square_Attribute = "_SquareAttribute";
        public static string _Moustache_Attribute = "_MoustacheAttribute";
        public static string _Diamond_Attribute = "_DiamondAttribure";
        public static string _Display_status = "_DisplayStatus";
        public static string _Blink_status = "_BlinkStatus";
        public static string _MDT_status = "_MDTStatus";

        #endregion
        #region Threat Data Feilds For Double
        public static string _Azimuth = "_Azimuth";
        public static string _ThreatRange = "_ThreatRange";
        #endregion


        #region Threat Suffixes
        public static HashSet<string> threatSuffixes = new HashSet<string>
        {
            Common._Threat_Presence,
            Common._Threat_symbol_code,
            Common._Threat_Alt_symbolcode,
            Common._Threat_sym_FG_colour,
            Common._Threatsym_BG_colour,
            Common._circle_Attribute,
            Common._Square_Attribute,
            Common._Moustache_Attribute,
            Common._Diamond_Attribute,
            Common._Display_status,
            Common._Blink_status,
            Common._MDT_status,

        };
        #endregion

        #region IntTypeEmitterSuffixed
        public static HashSet<string> IntTypeEmitterSuffix = new HashSet<string>
        {
            Common._Threat_symbol_code,
            Common._Threat_Alt_symbolcode,
            Common._ThreatRange
        };
        #endregion

        #region
        public static HashSet<string> DobuleTypeForThreat = new HashSet<string>
        {
            Common._Azimuth,
        };   
        #endregion

        public static string MasterDataCache = "MasterDataCache";
        public static string Emitter = "Emitter";

        public static DataTable ConvertToDataTable(List<Dictionary<string, object>> data, List<string> columns)
        {
            DataTable table = new DataTable();
            if (data.Count == 0) return table;

            // Add columns dynamically
            //foreach (var key in data.First().Keys)
            //    table.Columns.Add(key, typeof(string));

            foreach (var key in columns)
                table.Columns.Add(key, typeof(string));

            // Add rows
            foreach (var row in data)
            {
                DataRow newRow = table.NewRow();
                foreach (var key in row.Keys)
                    newRow[key] = row[key]?.ToString();
                table.Rows.Add(newRow);
            }

            return table;
        }
        public static double ConvertToMiliSecondss(string Time)
        {
            double totalMilliseconds = 0;
            try
            {
                // Parse time string into TimeSpan
                TimeSpan time = TimeSpan.ParseExact(Time, @"hh\:mm\:ss\.fff", null);

                // Convert to total milliseconds
                totalMilliseconds = time.TotalMilliseconds;
            }
            catch (Exception)
            {
                throw;
            }
            return totalMilliseconds;
        }

        public static List<Dictionary<string, object>> MergeDataByTime(List<Dictionary<string, object>> methodData)
        {
            Dictionary<string, Dictionary<string, object>> mergedDictionary = new Dictionary<string, Dictionary<string, object>>();

            foreach (var record in methodData)
            {
                string utcTime = record["UTC_Time"].ToString();

                if (!mergedDictionary.ContainsKey(utcTime))
                {
                    mergedDictionary[utcTime] = new Dictionary<string, object> { { "UTC_Time", utcTime } };
                }

                foreach (var kvp in record)
                {
                    if (!mergedDictionary[utcTime].ContainsKey(kvp.Key) && kvp.Key != "UTC_Time")
                    {
                        mergedDictionary[utcTime][kvp.Key] = kvp.Value;
                    }
                }
            }

            return mergedDictionary.Values.ToList();
        }


        public static List<Dictionary<string, object>> SortAndGroupByTime(List<Dictionary<string, object>> data)
        {
            // Sort data based on UTC_Time
            List<Dictionary<string, object>> sortedList = data.OrderBy(d => d["UTC_Time"]).ToList();

            // List to store the final structured data
            List<Dictionary<string, object>> groupedData = new List<Dictionary<string, object>>();

            foreach (var record in sortedList)
            {
                // Check if any existing row has the same UTC_Time
                var existingRow = groupedData.FirstOrDefault(row => row["UTC_Time"].ToString() == record["UTC_Time"].ToString());

                if (existingRow == null)
                {
                    // If no row exists for this time, add it as a new row
                    groupedData.Add(new Dictionary<string, object>(record));
                }
                else
                {
                    // If the same time exists, check if all fields are different
                    bool isDuplicate = record.All(kv => existingRow.ContainsKey(kv.Key) && object.Equals(existingRow[kv.Key], kv.Value));

                    if (!isDuplicate)
                    {
                        // If it's a different record (same time but different data), add it as a new row
                        groupedData.Add(new Dictionary<string, object>(record));
                    }
                }
            }

            return groupedData;
        }

        public static DataTable ConvertToDataTableNew(List<Dictionary<string, object>> data, List<string> columnsss)
        {
            DataTable dt = new DataTable();

            if (data.Count == 0)
                return dt;

            // Get all unique column names (trimmed)
            var allColumns = new HashSet<string>(data.SelectMany(dict => dict.Keys.Select(k => k.Trim())));

            // Add columns to DataTable
            foreach (var column in allColumns)
            {
                dt.Columns.Add(column, typeof(object)); // Default type as object
            }

            // Add data rows
            foreach (var record in data)
            {
                DataRow row = dt.NewRow();
                foreach (var kvp in record)
                {
                    string trimmedKey = kvp.Key.Trim(); // Trim column name
                    row[trimmedKey] = kvp.Value ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        public static List<Dictionary<string, object>> ProcessData(List<Dictionary<string, object>> data)
        {
            // Sort data by UTC_Time
            var sortedData = data.OrderBy(d => d["UTC_Time"].ToString()).ToList();

            List<Dictionary<string, object>> processedData = new List<Dictionary<string, object>>();
            Dictionary<string, int> timeCounter = new Dictionary<string, int>();

            foreach (var record in sortedData)
            {
                string utcTime = record["UTC_Time"].ToString().Trim();

                // If UTC_Time already exists, add a new row (instead of merging)
                if (!timeCounter.ContainsKey(utcTime))
                    timeCounter[utcTime] = 0;
                else
                    timeCounter[utcTime] += 1;

                // Copy original record (without adding UniqueTimeKey)
                Dictionary<string, object> newRow = new Dictionary<string, object>(record);

                processedData.Add(newRow);
            }

            return processedData;
        }

        public static string ConvertToTimeSpan(string TimeData)
        {
            try
            {
                string Output = string.Empty;
                string[] parts = TimeData.Split(':');
                if (parts.Length == 4)
                {
                    int hours = int.Parse(parts[0]);
                    int minutes = int.Parse(parts[1]);
                    int seconds = int.Parse(parts[2]);
                    int milliseconds = int.Parse(parts[3]);

                    return Output = $"{hours:D2}:{minutes:D2}:{seconds:D2}.{milliseconds:D3}";

                }
                return Output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static byte[] CompressGzip(string data)
        {
            using var memoryStream = new MemoryStream();
            using var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress);
            using var writer = new StreamWriter(gzipStream);

            writer.Write(data);
            writer.Flush();
            gzipStream.Flush();

            return memoryStream.ToArray();
        }


        // Convert Dictionary List to DataTable
        public static DataTable ConvertToDataTable(List<Dictionary<string, object>> data)
        {
            DataTable dt = new DataTable();
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
            return dt;
        }


        // Merge Data Using Binary Search for Efficient Lookups
        public static DataTable MergeDataTables(DataTable nav, DataTable etr, DataTable threat, DataTable radar)
        {
            DataTable mergedTable = new DataTable();

            // Define columns
            mergedTable.Columns.Add("UTC_Time", typeof(string));
            mergedTable.Columns.Add("NavData", typeof(string));
            mergedTable.Columns.Add("EtrData", typeof(string));
            mergedTable.Columns.Add("ThreatData", typeof(string));
            mergedTable.Columns.Add("RadarData", typeof(string));

            // Convert to Sorted Lists for Fast Lookup
            var etrList = etr.AsEnumerable().OrderBy(row => ParseTime(row["UTC_Time"].ToString())).ToList();
            var threatList = threat.AsEnumerable().OrderBy(row => ParseTime(row["UTC_Time"].ToString())).ToList();
            var radarList = radar.AsEnumerable().OrderBy(row => ParseTime(row["UTC_Time"].ToString())).ToList();

            foreach (DataRow navRow in nav.Rows)
            {
                string utcTime = navRow["UTC_Time"].ToString();
                TimeSpan navTime = ParseTime(utcTime);

                DataRow newRow = mergedTable.NewRow();
                newRow["UTC_Time"] = utcTime;
                newRow["NavData"] = navRow["NavData"];

                // Fetch closest data from ETR, Threat, and Radar
                newRow["EtrData"] = FindClosestData(etrList, navTime);
                newRow["ThreatData"] = FindClosestData(threatList, navTime);
                newRow["RadarData"] = FindClosestData(radarList, navTime);

                mergedTable.Rows.Add(newRow);
            }

            return mergedTable;
        }

        static string FindExactData(DataTable dataTable, TimeSpan targetTime)
        {
            var row = dataTable.AsEnumerable()
                .FirstOrDefault(r => ParseTime(r["UTC_Time"].ToString()) == targetTime);
            return row != null ? row.ItemArray.Last().ToString() : "";
        }

        // Binary Search for Closest UTC_Time (Microseconds Precision)
        public static string FindClosestData(List<DataRow> etrList, TimeSpan navTime)
        {
            if (etrList.Count == 0)
                return null; // No ETR data available

            List<string> closestData = new List<string>();

            foreach (DataRow row in etrList)
            {
                TimeSpan etrTime = ParseTime(row["UTC_Time"].ToString());

                // If exact match or within ±1 second, add to list
                if (Math.Abs((etrTime - navTime).TotalMilliseconds) <= 1000)
                {
                    closestData.Add(row.ItemArray.Last().ToString());
                }
            }

            return closestData.Count > 0 ? string.Join(", ", closestData) : null;
        }

        // Convert UTC Time String to DateTime with Microsecond Precision
        public static TimeSpan ParseTime(string timeStr)
        {
            // Convert `09:58:58:245` to `09:58:58.245`
            if (timeStr.Count(c => c == ':') == 3)
            {
                timeStr = ReplaceLastOccurrence(timeStr, ":", ".");
            }

            return TimeSpan.ParseExact(timeStr, "hh\\:mm\\:ss\\.fff", System.Globalization.CultureInfo.InvariantCulture);
        }
        public static string FormatTime(TimeSpan time)
        {
            return time.ToString(@"hh\:mm\:ss\:fff");
        }

        // Replace Last Occurrence of a Character (Fix Incorrect `:`)
        public static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);
            if (place == -1)
                return source;
            return source.Remove(place, find.Length).Insert(place, replace);
        }

        public static List<Dictionary<string, object>> MergeDictionaries(
        List<Dictionary<string, object>> navData,
        List<Dictionary<string, object>> etrData,
        List<Dictionary<string, object>> threatData,
        List<Dictionary<string, object>> radarData)
        {
            var result = new List<Dictionary<string, object>>();
            HashSet<string> columns = new HashSet<string> { "UTC_Time" };

            // Helper function to parse UTC time
            DateTime ParseTime(string time)
            {
                return DateTime.ParseExact(time, "HH:mm:ss:fff", null);
            }

            // Convert NAV times into sorted list
            List<DateTime> navTimes = navData.Select(n => ParseTime(n["UTC_Time"].ToString())).OrderBy(t => t).ToList();

            // Store NAV data in result
            foreach (var navEntry in navData)
            {
                var row = new Dictionary<string, object>(navEntry)
                {
                    ["UTC_Time"] = navEntry["UTC_Time"]
                };
                result.Add(row);
            }

            // Function to merge data sources while ensuring NAV is duplicated correctly
            void MergeData(List<Dictionary<string, object>> dataList, string columnName)
            {
                List<Dictionary<string, object>> additionalRows = new List<Dictionary<string, object>>();

                foreach (var entry in dataList)
                {
                    DateTime dataTime = ParseTime(entry["UTC_Time"].ToString());
                    bool matchFound = false;

                    // **First Priority: Match based on closest milliseconds**
                    var closestMillisecondMatches = navTimes
                        .Where(t => Math.Abs((t - dataTime).TotalMilliseconds) <= 10) // Millisecond check
                        .OrderBy(t => Math.Abs((t - dataTime).TotalMilliseconds))
                        .ToList();

                    if (closestMillisecondMatches.Any())
                    {
                        matchFound = true; // **Breaks here, so seconds are NOT checked**
                        foreach (var closestTime in closestMillisecondMatches)
                        {
                            string closestTimeString = closestTime.ToString("HH:mm:ss:fff");

                            var matchingRows = result.Where(r => r["UTC_Time"].ToString() == closestTimeString).ToList();
                            int matchCount = dataList.Count(d => ParseTime(d["UTC_Time"].ToString()) == dataTime);

                            // Ensure NAV appears exactly as many times as needed
                            for (int i = 0; i < Math.Min(matchCount, matchingRows.Count); i++)
                            {
                                var newRow = new Dictionary<string, object>(matchingRows[i]);
                                foreach (var kv in entry)
                                {
                                    if (kv.Key != "UTC_Time")
                                    {
                                        newRow[kv.Key] = kv.Value;
                                        columns.Add(kv.Key);
                                    }
                                }
                                additionalRows.Add(newRow);
                            }
                        }
                    }

                    // **Only check closest seconds if no milliseconds match was found**
                    if (!matchFound)
                    {
                        var closestSecondMatches = navTimes
                            .Where(t => Math.Abs((t - dataTime).TotalSeconds) <= 2) // Second-level check
                            .OrderBy(t => Math.Abs((t - dataTime).TotalSeconds))
                            .ToList();

                        if (closestSecondMatches.Any())
                        {
                            foreach (var closestTime in closestSecondMatches)
                            {
                                string closestTimeString = closestTime.ToString("HH:mm:ss:fff");

                                var matchingRows = result.Where(r => r["UTC_Time"].ToString() == closestTimeString).ToList();
                                int matchCount = dataList.Count(d => ParseTime(d["UTC_Time"].ToString()) == dataTime);

                                // Ensure NAV appears exactly as many times as needed
                                for (int i = 0; i < Math.Min(matchCount, matchingRows.Count); i++)
                                {
                                    var newRow = new Dictionary<string, object>(matchingRows[i]);
                                    foreach (var kv in entry)
                                    {
                                        if (kv.Key != "UTC_Time")
                                        {
                                            newRow[kv.Key] = kv.Value;
                                            columns.Add(kv.Key);
                                        }
                                    }
                                    additionalRows.Add(newRow);
                                }
                            }
                        }
                    }
                }

                // Add newly created rows after processing to avoid infinite loops
                result.AddRange(additionalRows);
            }

            // Merge Other Data Sources
            MergeData(etrData, "ETR");
            MergeData(threatData, "ThreatData");
            MergeData(radarData, "RadarData");

            // Ensure all columns exist in every row
            foreach (var row in result)
            {
                foreach (var col in columns)
                {
                    if (!row.ContainsKey(col))
                        row[col] = DBNull.Value;
                }
            }

            return result.OrderBy(r => ParseTime(r["UTC_Time"].ToString())).ToList(); // Ensure sorted order
        }

        public static DataTable ConvertToDataTabless(List<Dictionary<string, object>> mergedData)
        {
            DataTable table = new DataTable();

            if (mergedData.Count == 0)
                return table;

            // Add columns dynamically
            foreach (var column in mergedData.First().Keys)
                table.Columns.Add(column, typeof(object));

            // Add rows
            foreach (var row in mergedData)
            {
                DataRow dataRow = table.NewRow();
                foreach (var kv in row)
                    dataRow[kv.Key] = kv.Value ?? DBNull.Value; // Ensure NULL values are handled

                table.Rows.Add(dataRow);
            }

            return table;
        }


        public static List<Dictionary<string, object>> MergeDictionariesnew(
         List<Dictionary<string, object>> etrData,
         List<Dictionary<string, object>> navData,
         List<Dictionary<string, object>> threatData,
         List<Dictionary<string, object>> radarData)
        {
            var mergedResult = new List<Dictionary<string, object>>();

            foreach (var etr in etrData)
            {
                var mergedRow = new Dictionary<string, object>(etr);
                MergeData(navData, mergedRow);
                MergeData(threatData, mergedRow);
                MergeData(radarData, mergedRow);
                mergedResult.Add(mergedRow);
            }

            return mergedResult;
        }

        public static void MergeData(List<Dictionary<string, object>> sourceData, Dictionary<string, object> targetRow)
        {
            string utcTime = targetRow["UTC_Time"].ToString();
            var closestMatch = sourceData.OrderBy(d => GetTimeDifference(d["UTC_Time"].ToString(), utcTime)).FirstOrDefault();

            if (closestMatch != null)
            {
                foreach (var kvp in closestMatch)
                {
                    if (!targetRow.ContainsKey(kvp.Key))
                        targetRow[kvp.Key] = kvp.Value;
                }
            }
        }

        public static int GetTimeDifference(string time1, string time2)
        {
            TimeSpan t1, t2;

            // Ensure the time format is valid
            if (!TryParseTime(time1, out t1) || !TryParseTime(time2, out t2))
                return int.MaxValue; // If parsing fails, return a large value to avoid incorrect matches

            return Math.Abs((int)(t1 - t2).TotalMilliseconds);
        }

        public static bool TryParseTime(string timeStr, out TimeSpan time)
        {
            // Ensure proper format and handle missing milliseconds
            if (!timeStr.Contains(":"))
            {
                time = TimeSpan.Zero;
                return false;
            }

            // Normalize time format
            string[] parts = timeStr.Split(':');
            if (parts.Length < 4)
            {
                timeStr += ":000"; // Add missing milliseconds if not present
            }

            return TimeSpan.TryParseExact(timeStr, "hh\\:mm\\:ss\\:fff", null, out time);
        }

        public static int TimeDifference(string time1, string time2)
        {
            TimeSpan t1 = TimeSpan.ParseExact(time1, "hh:mm:ss:fff", null);
            TimeSpan t2 = TimeSpan.ParseExact(time2, "hh:mm:ss:fff", null);
            return Math.Abs((int)(t1 - t2).TotalMilliseconds);
        }


        public static TimeSpan ConvertToTimeSpannew(string timeStr)
        {
            return TimeSpan.ParseExact(timeStr, @"hh\:mm\:ss\:fff", null);
        }


        public static async Task<(List<Dictionary<string, object>>, List<Dictionary<string, object>>, List<Dictionary<string, object>>, List<Dictionary<string, object>>)>
        LoadCsvFilesConcurrently(string etrPath, string navPath, string radarPath, string threatPath)
        {
            var etrTask = Task.Run(() => CsvToDic.Convert(etrPath));
            var navTask = Task.Run(() => CsvToDic.Convert(navPath));
            var radarTask = Task.Run(() => CsvToDic.Convert(radarPath));
            var threatTask = Task.Run(() => CsvToDic.Convert(threatPath));

            await Task.WhenAll(etrTask, navTask, radarTask, threatTask);
            return (etrTask.Result, navTask.Result, radarTask.Result, threatTask.Result);
        }

        public static TimeSpan TrimMilliseconds(TimeSpan timeSpan)
        {
            return new TimeSpan(0, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        }

        public static void GenerateJson(string strFile)
        {
            try
            {
                string filePath = "D:\\outputJson\\test.json"; // Change path as needed
                // Write JSON string to file
                File.WriteAllText(filePath, strFile);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region It will Add Emitter,Nav,others also with repeted Data
        public static async Task<APIResponse> SortDataForUI(List<MasterPMDARecords> SortedResult)
        {
            try
            {
                APIResponse objRespo = new APIResponse();
                #region Sorting Data for FrontEnd Team
                Dictionary<TimeSpan, List<object>> myDict = new Dictionary<TimeSpan, List<object>>();
                List<UIResponse> lstUIResponse = new List<UIResponse>();
                List<List<object>>? lstEmitters = new List<List<object>>();
                int tt = 0;

                objRespo.headers = new Headers();
                objRespo.headers.Rdr = new List<string>();
                objRespo.headers.Rdr = Common.RadarHeaders;

                objRespo.headers.Tht = new List<string>();
                objRespo.headers.Tht = Common.ThreatHeaders;

                objRespo.headers.Nav = new List<string>();
                objRespo.headers.Nav = Common.NavHeaders;

                objRespo.headers.Etr = new List<string>();
                objRespo.headers.Etr = Common.EmitterHeaders;
                lstUIResponse = new List<UIResponse>();
                TimeSpan UTC_TIME = new TimeSpan();
                TimeSpan Time = new TimeSpan();

                foreach (var record in SortedResult)
                {
                    HeaderValues objHeaderValues = new HeaderValues();
                    objHeaderValues = new HeaderValues();

                    tt++;
                    UTC_TIME = new TimeSpan();
                    Time = new TimeSpan();
                    PropertyInfo[] properties = record.GetType().GetProperties();
                    UIResponse objUiResponse = new UIResponse();
                    List<object> _ThreatValues = new List<object>();
                    List<object> _NavValues = new List<object>();
                    List<object> _EmitterValues = new List<object>();
                    List<object> _RadarValues = new List<object>();

                    foreach (var property in properties)
                    {
                        objUiResponse = new UIResponse();
                        objUiResponse.Data = new HeaderValues();

                        string propertyName = property.Name; // Property name
                        object propertyValue = property.GetValue(record); // Property value

                        if (propertyName == "UTC_Time")
                            UTC_TIME = (TimeSpan)propertyValue;

                        if (propertyName == "Time")
                            Time = (TimeSpan)propertyValue;

                        if (Common.ThreatHeaders.Contains(propertyName))
                        {
                            _ThreatValues.Add(propertyValue);
                            continue;
                        }
                        if (Common.EmitterHeaders.Contains(propertyName))
                        {
                            _EmitterValues.Add(propertyValue);
                            continue;
                        }
                        if (Common.NavHeaders.Contains(propertyName))
                        {
                            _NavValues.Add(propertyValue);
                            continue;
                        }
                        if (Common.RadarHeaders.Contains(propertyName))
                        {
                            _RadarValues.Add(propertyValue);
                            continue;
                        }
                    }
                    
                    if (!myDict.ContainsKey(Time))
                    {
                        lstUIResponse = new List<UIResponse>();
                        lstEmitters = new List<List<object>>();

                        myDict[Time] = new List<object>();

                        objHeaderValues.tht = _ThreatValues;
                        objHeaderValues.rdr = _RadarValues;
                        objHeaderValues.nav = _NavValues;

                        //objHeaderValues.UTC_Time = UTC_TIME;

                        lstEmitters.Add(_EmitterValues);
                        objHeaderValues.etr = lstEmitters;

                        objUiResponse.Data = objHeaderValues;
                        lstUIResponse.Add(objUiResponse);
                        myDict[Time].Add(lstUIResponse);
                    }
                    else
                    {
                        lstEmitters.Add(_EmitterValues);
                        objUiResponse.Data.etr.Add(lstEmitters[lstEmitters.Count-1]);                   

                        myDict[Time].Clear();
                        myDict[Time].Add(lstUIResponse);
                        objHeaderValues = new HeaderValues();
                    }

                    //if (tt == 30)
                    //    break;
                }

                #endregion
                objRespo.uiData = myDict;
                return objRespo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        //public static async metadata GenerateEmitterMetaData(List<Dictionary<string, object>> EtrData)
        //{
        //    metadata objMetaData = new metadata();
        //    try
        //    {
        //        List<emitters> lstEmitter = new List<emitters>();
        //        for (int i = 0; i < EtrData.Count; i++)
        //        {
        //            emitters objemiter = new emitters();
        //            string EmiterId = EtrData[i]["EmitterId"].ToString();
        //            if (!EmitterData.Contains(EmiterId))
        //            {
        //                EmitterData.Add(EmiterId);
        //                objemiter.EmitterId = EmiterId;
        //                lstEmitter.Add(objemiter);
        //            }
        //        }
        //        objMetaData.description = "PMDA_Testing";
        //        objMetaData.total_emitters = EmitterData.Count;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public static async Task<List<FlightRoutes>> SortFlightRoute(List<MasterPMDARecords> SortedData)
        {
            try
            {
                List<FlightRoutes> FlightRoutes = new List<FlightRoutes>();
                foreach (var item in SortedData)
                {
                    FlightRoutes objFlight = new FlightRoutes();
                    objFlight.UTC = item.UTC_Time;
                    string _TIME = item.Time.ToString();
                    TimeSpan time = TimeSpan.Parse(_TIME);
                    // Convert TimeSpan to milliseconds
                    double milliseconds = time.TotalMilliseconds;
                    objFlight.Time = milliseconds;
                    objFlight.Lat = item.PresentPosLatitude;
                    objFlight.Long = item.PresentPosLongitude;

                    objFlight.TrueHeading_pi_rad = item.TrueHeading_pi_rad;
                    objFlight.PitchAngle_pi_rad = item.PitchAngle_pi_rad;
                    objFlight.RollAngle_pi_rad = item.RollAngle_pi_rad;
                    objFlight.Altitude_m = item.Altitude_m;
                    FlightRoutes.Add(objFlight);
                }
                return FlightRoutes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task<APIResponse> MergeAPIResponse(APIResponse result, APIResponse response)
        {
            // Ensure result.uiData is initialized as a dictionary if it's null
            if (result.uiData == null)
            {
                result.uiData = new Dictionary<TimeSpan, List<object>>(); // Initialize if it's null
            }

            // Ensure response.uiData is not null before trying to merge
            if (response.uiData != null)
            {
                foreach (var kvp in response.uiData)
                {
                    // Check if the key already exists in the result dictionary
                    if (result.uiData.ContainsKey(kvp.Key))
                    {
                        // If the key exists, merge the lists but ensure no duplicates are added
                        var existingData = result.uiData[kvp.Key];

                        // Adding only distinct records based on object comparison
                        var newData = kvp.Value.Where(item => !existingData.Contains(item)).ToList();

                        // Add only the non-duplicate records
                        existingData.AddRange(newData);
                    }
                    else
                    {
                        // If the key does not exist, create a new entry with the current list
                        result.uiData[kvp.Key] = new List<object>(kvp.Value);
                    }
                }
            }

            // Return the merged APIResponse object
            return result;
        }

        public static int CalculateBatchSize(int totalRecords)
        {
            // Here you can use a simple formula to determine batch size dynamically
            // Example: A smaller batch size for larger datasets, a larger batch size for smaller datasets
            if (totalRecords < 100000)
            {
                return 10000; // Small data, larger batch
            }
            else if (totalRecords < 500000)
            {
                return 50000; // Medium data, moderate batch
            }
            else
            {
                return 100000; // Large data, smaller batch
            }
        }

       

        public static  List<DataTable> SplitDataTable(DataTable originalTable, int batchSize)
        {
            var batches = new List<DataTable>();
            int totalRows = originalTable.Rows.Count;
            int currentIndex = 0;

            while (currentIndex < totalRows)    
            {
                var batchTable = originalTable.Clone(); // Clone structure only
                int limit = Math.Min(batchSize, totalRows - currentIndex);

                for (int i = 0; i < limit; i++)
                {
                    batchTable.ImportRow(originalTable.Rows[currentIndex]);
                    currentIndex++;
                }
                batches.Add(batchTable);
            }
            return batches;
        }


        public static int CalculateMaxDegreeOfParallelism(int totalBatches)
        {
            // Get the number of available CPU cores
            int availableCores = Environment.ProcessorCount;

            // Dynamically adjust based on total batches and available cores
            // If you have a very small number of batches, don't spawn too many tasks
            if (totalBatches <= 10)
            {
                return 2; // For small datasets, use a lower number of parallel tasks
            }
            else if (totalBatches <= 50)
            {
                return Math.Min(4, availableCores); // For medium datasets, use up to 4 parallel tasks
            }
            else
            {
                return Math.Min(availableCores, 8); // For large datasets, use more parallelism but limit to the number of available cores
            }
        }



    }
}
