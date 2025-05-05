using PMDA_API.Models;
using System.Data;

namespace PMDA_API.Interface
{
    public interface IPMDA
    {
        public Task<DataTable> GetCsvMasterData();
        public  Task<string> SaveCsvFileIntoDB(DataTable dataTable);
        public void Delete();
        public Task<FlightData> GetFlightData();
        public List<MasterPMDARecords> GetMasterPMDA();
        public Task<bool> SaveMetaData(string strFile);
        public Task<metadata> GetMetaData();
        public Task<string> SaveBatchIntoDB(DataTable batchTable);
        Task<string> BulkInsertDataTable(DataTable dataTable);


    }
}
