using MongoDB.Driver;
using MongoDB.Utility;

namespace MongoDB.Model
{

    public class EmployeeDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoDatabaseSettings _mongoDatabaseSettings;
        public EmployeeDBContext(IMongoDatabaseSettings mongoDatabaseSettings)
        {
            _mongoDatabaseSettings = mongoDatabaseSettings;
            var client = new MongoClient(_mongoDatabaseSettings.ConnectionString);
            _mongoDatabase = client.GetDatabase(_mongoDatabaseSettings.DatabaseName);

        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return _mongoDatabase.GetCollection<Employee>("EmployeeRecord");
            }
        }

        public IMongoCollection<Cities> CityRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Cities>("Cities");
            }
        }
    }
}
