using PMDA_API.Models;

namespace PMDA_API
{
    public class MasterPMDACacheService
    {
        private List<MasterPMDARecords> _cachedData;

        public List<MasterPMDARecords> GetData() => _cachedData;

        public void SetData(List<MasterPMDARecords> data)
        {
            _cachedData = data;
        }
    }
}
