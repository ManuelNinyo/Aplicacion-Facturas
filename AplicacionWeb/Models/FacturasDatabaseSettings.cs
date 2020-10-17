namespace webAPI.Models
{
    public class FacturasDatabaseSettings : IFacturasDatabaseSettings
    {
        public string FacturasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFacturasDatabaseSettings
    {
        string FacturasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}