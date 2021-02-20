namespace PrismFullNavigation.Services.Data
{
    public class DataService : IDataService
    {
        public bool ClearDetailPageStack { get; set; }

        public DataService()
        {
            ClearDetailPageStack = true;
        }
    }
}
