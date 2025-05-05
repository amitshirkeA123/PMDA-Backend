
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PMDA_API.Interface;
using PMDA_API.Models;
using System.Data;
using System.IO.Compression;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PMDA_API.Services
{
    public class PMDA_Service : IPMDA
    {
        readonly string connectionString;
        public PMDA_Service(IConfiguration _configuration)
        {
            connectionString = _configuration["SqlConnectionString:MySqlDBConnectionString"];
        }

        public async Task<string> BulkInsertDataTable(DataTable dataTable)
        {
            string response = "Insert Successful";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Set the destination table for the bulk insert
                    using (var bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "MasterDataForPMDA_V4"; // Set your table name here
                        bulkCopy.BatchSize = 10000; // Set your batch size for bulk inserts
                        bulkCopy.NotifyAfter = 10000; // Notify every 10,000 rows
                        bulkCopy.BulkCopyTimeout = 300000; // Set bulk insert timeout to 10 minutes (600 seconds)
                        bulkCopy.SqlRowsCopied += (sender, e) =>
                        {
                            Console.WriteLine($"{e.RowsCopied} rows copied.");
                        };

                        await bulkCopy.WriteToServerAsync(dataTable); // Perform the bulk insert
                    }
                }
            }
            catch (Exception ex)
            {
                response = $"Error: {ex.Message}";
            }

            return response;
        }

        #region Delete Records
        public void Delete()
        {
            #region Sql Operations
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "GetMasterData4";
                    cmd.CommandText = "DeleteData";
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 5400; // Increase timeout to 120 seconds
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            #endregion
        }
        #endregion

        #region Getting CsvMasterData
        public async Task<DataTable> GetCsvMasterData()
        {
            DataTable dt_Datatable = new DataTable();
            #region Sql Operations
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "GetMasterTableDataForPMDA";
                    cmd.Connection = conn;
                    cmd.CommandTimeout = 5400; // Increase timeout to 120 seconds
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt_Datatable);
                    List<MasterPMDARecords> lstMasterData = new List<MasterPMDARecords>();
                    for (int i = 0; i < dt_Datatable.Rows.Count; i++)
                    {
                        MasterPMDARecords objMasterData = new MasterPMDARecords();
                        objMasterData.UTC_Time = (TimeSpan)dt_Datatable.Rows[i]["UTC_Time"];
                        objMasterData.ThreatCount = (int)dt_Datatable.Rows[i]["ThreatCount"];
                        string jsonThreatDetails = dt_Datatable.Rows[i]["ThreatDetails"].ToString();
                        //objMasterData.ThreatDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonThreatDetails);
                        lstMasterData.Add(objMasterData);
                    }
                }
            }
            #endregion
            return dt_Datatable;
        }
        #endregion

        #region Getting Flight Json Data
        public async Task<FlightData> GetFlightData()
        {
            FlightData objFlight = new FlightData();
            DataTable dt_Response = new DataTable();
            try
            {
                //string jsonFilePath = "D:\\Constelli\\PMDA_API\\B15\\PMDA_API\\PMDA_API\\FlightPath_Json\\flight_data_with_null_metadata 2.json";
                //string jsonData = File.ReadAllText(jsonFilePath);

                #region Sql Operations
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    DataTable dataTable = new DataTable();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //cmd.CommandText = "MasterInsertCsvFilestest2";
                        cmd.CommandText = "GetFlightData";
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt_Response);
                    }
                }
                #endregion
                string jsonData = dt_Response.Rows[0]["JsonData"].ToString();
                objFlight = JsonConvert.DeserializeObject<FlightData>(jsonData);
                string JsonFile = JsonConvert.SerializeObject(objFlight);
            }
            catch (Exception)
            {
                throw;
            }
            return objFlight;
        }
        #endregion

        #region Getting Master PMDA Records From DataBase 
        public List<MasterPMDARecords> GetMasterPMDA()
        {
            //List<MasterPMDARecords> lstMasterData = new List<MasterPMDARecords>();
            string ResultPMDAJson = string.Empty;
            List<MasterPMDARecords> masterDataLisft;
            #region Taking Data From MasterDataForPMDA_V4 table
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //string query = "SELECT * FROM MasterDataForPMDA_V3";
                    string query = "SELECT * FROM MasterDataForPMDA_V4";
                    masterDataLisft = conn.Query<MasterPMDARecords>(query).ToList();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return masterDataLisft;

            #endregion
        }

        public async Task<metadata> GetMetaData()
        {
            metadata objMetaData = new metadata();
            try
            {
                //List<MasterPMDARecords> lstMasterData = new List<MasterPMDARecords>();
                string ResultPMDAJson = string.Empty;

                #region Taking Data From MetaDatastr table
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT TOP 1 MetaDatastr FROM tblMetaData";
                        ResultPMDAJson = conn.QueryFirstOrDefault<string>(query);
                        conn.Close();
                    }

                    // Deserialize JSON if the column `SerializedData` contains a JSON string
                    objMetaData = JsonConvert.DeserializeObject<metadata>(ResultPMDAJson);

                }
                catch (Exception)
                {
                    throw;
                }
                return objMetaData;

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> SaveBatchIntoDB(DataTable batchTable)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var cmd = new SqlCommand("Proc_InsertMasterDataForPMDA_V4", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UDT_CSV_FILES", batchTable);
                    cmd.CommandTimeout = 100000; // Increase timeout
                    await conn.OpenAsync();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt_Response = new DataTable();
                        adapter.Fill(dt_Response);

                        return dt_Response.Rows[0]["message"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error properly
                return $"Error: {ex.Message}";
            }
        }

        #endregion



        public async Task<string> SaveCsvFileIntoDB(DataTable dataTable)
        {
            string Response = "";

            #region Sql Operations
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "Proc_InsertMasterDataForPMDA_V4";
                        cmd.Parameters.AddWithValue("@UDT_CSV_FILES", dataTable);
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 100000; // Increase timeout to 120 seconds
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt_Response = new DataTable();
                        adapter.Fill(dt_Response);
                        Response = dt_Response.Rows[0]["message"].ToString();
                    }
                }
                return Response;
            }
            catch (Exception)
            {
                throw;
            }
            #endregion
        }

        public async Task<bool> SaveMetaData(string strFile)
        {
            #region Saving MetaData Into DB
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Define the INSERT query with a parameter
                    string query = "INSERT INTO tblMetaData (MetaDatastr) VALUES (@Value)";

                    // Execute the query with a parameter
                    int rowsAffected = conn.Execute(query, new { Value = strFile });

                    conn.Close();

                    // Optional: Return success/failure
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting data", ex);
            }
            #endregion

        }


       
       

    }
}
