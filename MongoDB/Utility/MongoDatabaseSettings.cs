namespace MongoDB.Utility
{
    public interface IMongoDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    {

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
