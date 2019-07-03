using MongoDB.Driver;
using MongoDB.Model;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        Employee GetEmployeeData(string id);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(string id);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext db;
        public EmployeeRepository(EmployeeDBContext db)
        {
            this.db = db;
        }
        //To Get all employees details         
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record         
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOne(employee);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular employee        
        public Employee GetEmployeeData(string id)
        {
            try
            {
                //FilterDefinition<Employee> filterEmployeeData = Builders<Employee>.Filter.Eq("Id", id);                //FilterDefinition<Employee> filterEmployeeData = Builders<Employee>.Filter.Eq("Id", id);

                return db.Employees.Find(e => e.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee        
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                //db.EmployeeRecord.ReplaceOne(filter: g => g.Id == employee.Id, replacement: employee);
                db.Employees.ReplaceOne(g => g.Id == employee.Id, employee);

            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee        
        public void DeleteEmployee(string id)
        {
            try
            {
                //FilterDefinition<Employee> employeeData = Builders<Employee>.Filter.Eq("Id", id);
                db.Employees.DeleteOne(e => e.Id == id);
            }
            catch
            {
                throw;
            }
        }
        // To get the list of Cities    
        public List<Cities> GetCityData()
        {
            try
            {
                return db.CityRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
