
using Dapper;
using Microsoft.Data.SqlClient;
using PMDA_API.Models;


namespace PMDA_API.Services
{
    public class MasterPMDALoaderService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly MasterPMDACacheService _cacheService;
        readonly string connectionString;
        private readonly string _connectionString;

        public MasterPMDALoaderService(IConfiguration _configuration, IServiceScopeFactory scopeFactory, MasterPMDACacheService cacheService)
        {
            _scopeFactory = scopeFactory;
            _cacheService = cacheService;
            connectionString = _configuration["SqlConnectionString:MySqlDBConnectionString"];
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(cancellationToken);
                    string query = "SELECT * FROM MasterDataForPMDA_V2";
                    var masterData = (await connection.QueryAsync<MasterPMDARecords>(query)).ToList();
                    _cacheService.SetData(masterData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading Master PMDA data: {ex.Message}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
