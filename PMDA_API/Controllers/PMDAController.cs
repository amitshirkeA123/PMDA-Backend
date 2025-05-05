using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using PMDA_API.Interface;
using StackExchange.Redis;
using PMDA_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Caching.Memory;
using MasterData2;
using System.IO.Compression;
using MessagePack;
using Azure;



namespace PMDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class PMDAController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        public List<MasterPMDARecords> CommonSortedData = new List<MasterPMDARecords>();
        private readonly StreamResponseService _streamResponseService;
        private readonly IPMDA _pMDAService;
        private readonly string _connectionString;
        private readonly IDatabase _redisDatabase;
        private string CacheKey = Common.MasterDataCache; // Redis key for master data
        private readonly MasterPMDACacheService _cacheService;
        public string cacheKey = "CachedData";

        public PMDAController(IPMDA pMDAService, IConnectionMultiplexer redis, IConfiguration configuration, StreamResponseService streamResponseService, MasterPMDACacheService cacheService, IMemoryCache cache)
        {
            _connectionString = configuration["SqlConnectionString:MySqlDBConnectionString"];
            _pMDAService = pMDAService;
            _redisDatabase = redis.GetDatabase();
            _streamResponseService = streamResponseService;
            // CommonSortedData =  _pMDAService.GetMasterPMDA();
            _cacheService = cacheService;
            _cache = cache;
        }


        [HttpDelete("DeleteCache")]
        public async Task<IActionResult> DeleteCache([FromBody] string cacheKey)
        {
            try
            {
                // Attempt to delete the key from Redis
                bool isDeleted = await _redisDatabase.KeyDeleteAsync(cacheKey);

                if (isDeleted)
                {
                    return Ok($"Cache key '{cacheKey}' deleted successfully.");
                }
                else
                {
                    return NotFound($"Cache key '{cacheKey}' not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., Redis connectivity issues)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteRecords")]
        public IActionResult DeleteRecords()
        {
            _pMDAService.Delete();
            return Ok("Deleted...");
        }


        public class DeleteCacheRequest
        {
            public string CacheKey { get; set; }
        }


        [HttpPost("SavePmdaData")]////currently working copy 26-3-25
        public async Task<IActionResult> SavePmdaData()
        {
            try
            {
                #region Working Code region
                //string folderPath = "D:\\adf\\MasterData\\csvfiles\\V5"; // Ensure CSV files are inside this folder
                string folderPath = "C:\\Constelli\\tonewlap\\tonewlap\\Latest_11-4-25"; // Ensure CSV files are inside this folder
                string etrFilePath = Path.Combine(folderPath, "ETR_data.csv");
                string navFilePath = Path.Combine(folderPath, "nav_sensor_data.csv");
                string radarFilePath = Path.Combine(folderPath, "radar_data.csv");
                string ThreatFilePath = Path.Combine(folderPath, "threat_data.csv");

                List<string> filePath = new List<string>();
                filePath.AddRange(new string[] { etrFilePath, navFilePath, radarFilePath, ThreatFilePath });

                List<string> EmitterData = new List<string>();

                List<Dictionary<string, object>> EtrData = CsvToDic.Convert(etrFilePath);
                List<Dictionary<string, object>> NavData = CsvToDic.Convert(navFilePath);
                List<Dictionary<string, object>> radarData = CsvToDic.Convert(radarFilePath);
                List<Dictionary<string, object>> threatData = CsvToDic.Convert(ThreatFilePath);

                #region Generating Emitter & Threat MetaDAta
                metadata objMetaData = new metadata();
                List<emitters> lstEmitter = await GenerateMetaData.SetMetaData(EtrData, EmitterData);
                HashSet<string> uniqueThreats = await GenerateMetaData.SetThreatMetaData(threatData);
                objMetaData.description = "PMDA_Testing";
                objMetaData.total_emitters = EmitterData.Count;
                #endregion

                var mergedData = CsvToDic.MergeDictionaries(EtrData, NavData, threatData, radarData);

                var sortedDAta = mergedData.OrderBy(a => a["UTC_Time"]).ToList();

                double navStartLatitude = double.Parse(sortedDAta[0]["PresentPosLatitude"].ToString());
                double navStartLongitude = double.Parse(sortedDAta[0]["PresentPosLongitude"].ToString());
                double navEndLatitude = double.Parse(sortedDAta[sortedDAta.Count - 1]["PresentPosLatitude"].ToString());
                double navEndLongitude = double.Parse(sortedDAta[sortedDAta.Count - 1]["PresentPosLongitude"].ToString());

                objMetaData.flight_start = new flight_start();
                objMetaData.flight_end = new flight_end();
                objMetaData.flight_start.Latitude = navStartLatitude;
                objMetaData.flight_start.Longitude = navStartLongitude;
                objMetaData.flight_end.Latitude = navEndLatitude;
                objMetaData.flight_end.Longitude = navEndLongitude;

                #region Mission Time
                TimeSpan TotalMissionTime = await GenerateMetaData.SetTotalMissionTime(sortedDAta);
                #endregion

                List<string> lstMasterColumns = new List<string>();
                lstMasterColumns.Add("Time");
                lstMasterColumns.Add("MilliSecond");
                foreach (var item in mergedData[0].Keys)
                {
                    lstMasterColumns.Add(item.ToString());
                }

                #region Feilds for MetaData
                string[] Feilds = new string[lstMasterColumns.Count - 1];
                Feilds = lstMasterColumns.ToArray();
                objMetaData.fields = lstMasterColumns.ToArray();
                objMetaData.emitters = lstEmitter.ToList();
                objMetaData.ThreatData = uniqueThreats.ToArray();
                objMetaData.TotalThreats = uniqueThreats.Count;
                objMetaData.MissionTime = TotalMissionTime;


                List<metadata> lstMetaData = new List<metadata>();
                lstMetaData.Add(objMetaData);
                #endregion

                #region Converting List To DataTable using Batch
                int totalRecords = mergedData.Count;
                int batchSize = Common.CalculateBatchSize(totalRecords);

                var tasks = new List<Task<DataTable>>();
                for (int i = 0; i < mergedData.Count; i += batchSize)
                {
                    var batchData = mergedData.Skip(i).Take(batchSize).ToList();
                    tasks.Add(Task.Run(() => convertToDataTable.ConvertToDataTable(batchData, lstMasterColumns)));
                }
                var results = await Task.WhenAll(tasks);
                DataTable Dt_finalResult = results.First();
                foreach (var batchResult in results.Skip(1))
                {
                    Dt_finalResult.Merge(batchResult); 
                }
                #endregion

                #region using batchBulk Insert
                var batches = Common.SplitDataTable(Dt_finalResult, 5000);
                var _task = batches.Select(batch => Task.Run(() => _pMDAService.SaveBatchIntoDB(batch))).ToList();
                var insertResult = await Task.WhenAll(_task);
                return Ok(insertResult);
                #endregion

                //string ResponseMsg = await _pMDAService.SaveCsvFileIntoDB(Dt_finalResult);
                //string strMetaData = JsonConvert.SerializeObject(objMetaData, Formatting.Indented);
                //bool IsMetaDataSaved = await _pMDAService.SaveMetaData(strMetaData);
                //return Ok(ResponseMsg);
                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetMetaData")]
        public async Task<IActionResult> GetMetaData()
        {
            string ResultJson = "";
            try
            {
                metadata objMetaData = await _pMDAService.GetMetaData();
                ResultJson = JsonConvert.SerializeObject(objMetaData, Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(ResultJson);
        }

        [HttpGet("GetFlightRoute")]//currently working code 7-4-25
        public async Task<IActionResult> GetFlightRoute()
        {
            string ResultJson = "";
            try
            {
                List<MasterPMDARecords> objMasterPMDARecords = _pMDAService.GetMasterPMDA();
                //ResultJson = JsonConvert.SerializeObject(objMetaData, Formatting.Indented);

                #region
                var uniqueRecords = objMasterPMDARecords
                .DistinctBy(record => record.UTC_Time)
                 .ToList();

                #endregion

                var SortedData = uniqueRecords.OrderBy(x => x.UTC_Time).ToList();
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


                    FlightRoutes.Add(objFlight);
                }
                //double navStartLatitude=double.Parse(SortedData[0].PresentPosLatitude.ToString());
                //double navStartLongitude = double.Parse(SortedData[0].PresentPosLongitude.ToString());

                FlightRouteContainer Result = new FlightRouteContainer { FlightRoutes = FlightRoutes };

                ResultJson = JsonConvert.SerializeObject(Result, Formatting.Indented);

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ResultJson);
        }

        [HttpGet("GetFlightRouteV2")]//currently working code 7-4-25 v2
        public async Task<IActionResult> GetFlightRouteV2()
        {
            string ResultJson = "";
            try
            {
                if (!_cache.TryGetValue(cacheKey, out List<MasterPMDARecords> IMemorycachedData))
                {
                    List<MasterPMDARecords> objMasterPMDARecords = _pMDAService.GetMasterPMDA();
                    var uniqueRecords = objMasterPMDARecords.DistinctBy(record => record.UTC_Time).ToList();
                    var SortedData = uniqueRecords.OrderBy(x => x.UTC_Time).ToList();
                    //var ResultFilterData = TimeConversion.FilterData(SortedData);
                    var ResultFilterData = await TimeConversion.FilterDataV2(SortedData);
                    List<FlightRoutes> FlightRoutes = await Common.SortFlightRoute(ResultFilterData);
                    FlightRouteContainer Result = new FlightRouteContainer { FlightRoutes = FlightRoutes };
                    ResultJson = JsonConvert.SerializeObject(Result, Formatting.Indented);
                    IMemorycachedData = ResultFilterData;
                    _cache.Set(cacheKey, IMemorycachedData);
                }
                else
                {
                    var CatcheMemoryData = IMemorycachedData;
                    List<FlightRoutes> FlightRoutes = await Common.SortFlightRoute(CatcheMemoryData);
                    FlightRouteContainer Result = new FlightRouteContainer { FlightRoutes = FlightRoutes };
                    ResultJson = JsonConvert.SerializeObject(Result, Formatting.Indented);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ResultJson);
        }

        [HttpGet("GetFlightRouteV3")]//with refresh rate parameter
        public async Task<IActionResult> GetFlightRouteV2([FromBody] int RefreshRate)
        {
            string ResultJson = "";
            try
            {
                List<MasterPMDARecords> objMasterPMDARecords = _pMDAService.GetMasterPMDA();
                var uniqueRecords = objMasterPMDARecords.DistinctBy(record => record.UTC_Time).ToList();
                var SortedData = uniqueRecords.OrderBy(x => x.UTC_Time).ToList();
                //var ResultFilterData = TimeConversion.FilterData(SortedData);
                var ResultFilterData = TimeConversion.FilterDataV3(SortedData, RefreshRate);
                List<FlightRoutes> FlightRoutes = await Common.SortFlightRoute(ResultFilterData);
                FlightRouteContainer Result = new FlightRouteContainer { FlightRoutes = FlightRoutes };
                ResultJson = JsonConvert.SerializeObject(Result, Formatting.Indented);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(ResultJson);
        }


        #region Currenlty working code till date 25-3-2025
        [HttpGet("GetPMDA")]
        public async Task<IActionResult> GetPMDA()
        {
            try
            {
                List<MasterPMDARecords> masterData = _pMDAService.GetMasterPMDA();
                if (masterData == null || !masterData.Any())
                    return NoContent();

                var SortedResult = masterData.OrderBy(a => a.UTC_Time).ToList();
                #region testing 

                int totalRecords = SortedResult.Count;
                int chunkSize;
                if (totalRecords <= 1000)
                {
                    chunkSize = 10; // Small datasets can use smaller chunk size
                }
                else if (totalRecords <= 10000)
                {
                    chunkSize = 100; // Moderate chunk size for medium datasets
                }
                else
                {
                    chunkSize = 500; // Larger chunk size for large datasets
                }

                List<List<MasterPMDARecords>> chunks = new List<List<MasterPMDARecords>>();
                for (int i = 0; i < totalRecords; i += chunkSize)
                {
                    chunks.Add(SortedResult.Skip(i).Take(chunkSize).ToList());
                }

                var tasks = chunks.Select(chunk => Task.Run(() => Common.SortDataForUI(chunk))).ToList();

                var results = await Task.WhenAll(tasks);

                List<APIResponse> mergedResponses = results.ToList(); // Collect all APIResponse objects
                APIResponse ResultOFData = new APIResponse();

                ResultOFData = mergedResponses.First();
                foreach (var response in mergedResponses)
                {
                    ResultOFData = await Common.MergeAPIResponse(ResultOFData, response); // Merging the entire APIResponse objects
                }

                int ttt = 0;
                #endregion

                //APIResponse ResultOFData = await Common.SortDataForUI(SortedResult);
               // APIResponse ResultOFDatae = await Common.SortDataForUI(SortedResult);

                var options = MessagePackSerializerOptions.Standard
                                .WithResolver(MessagePack.Resolvers.ContractlessStandardResolver.Instance);

                // Serialize with MessagePack
                byte[] msgPackData = MessagePackSerializer.Serialize(ResultOFData, options);

                // Compress using GZip
                using var outStream = new MemoryStream();
                using (var gzip = new GZipStream(outStream, CompressionLevel.Optimal, leaveOpen: true))
                {
                    gzip.Write(msgPackData, 0, msgPackData.Length);
                }

                outStream.Position = 0;

                //return File(compressedData, "application/octet-stream", "MasterData.msgpack.gz");
                return File(outStream.ToArray(), "application/gzip", "MasterData.msgpack.gz");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


    }
}
