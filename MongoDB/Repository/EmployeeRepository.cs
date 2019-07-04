using MongoDB.Driver;
using MongoDB.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoDB.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee AddEmployee(Employee employee);
        Employee GetEmployeeData(string id);
        Employee UpdateEmployee(Employee employee);
        bool DeleteEmployee(string id);
        Employee InsertAdderssByCustomerId(string id, Address address);
        Employee UpdateAdderssByCustomerId(string employeeId, Address address);
        Employee GetAdderssByAddrssName(string addressName);
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
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                db.Employees.InsertOne(employee);
                return employee;
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
        public Employee InsertAdderssByCustomerId(string id, Address address)
        {
            try
            {
                var update = Builders<Employee>.Update.Push("Address", address);
                db.Employees.UpdateOne(g => g.Id == id, update);

                return db.Employees.Find(e => e.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee UpdateAdderssByCustomerId(string employeeId, Address address)
        {
            try
            {

                var filter = Builders<Employee>.Filter.And(
                             Builders<Employee>.Filter.Eq(d => d.Id, employeeId), // main search item
                             Builders<Employee>.Filter.ElemMatch(x => x.Address, p => p.Id == address.Id));// child search item

                var update = Builders<Employee>.Update
                                .Set(c => c.Address[-1].Name, address.Name)
                                .Set(c => c.Address[-1].Place, address.Place);
                db.Employees.UpdateOne(filter, update);

                return db.Employees.Find(e => e.Id == employeeId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Employee GetAdderssByAddrssName(string addressName)
        {
            try
            {


                var filter = Builders<Employee>.Filter.ElemMatch(c => c.Address, c => c.Name.Equals(addressName));
                var result = db.Employees.Find(filter).FirstOrDefault();

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //To Update the records of a particluar employee        
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                //db.EmployeeRecord.ReplaceOne(filter: g => g.Id == employee.Id, replacement: employee);
                db.Employees.ReplaceOne(g => g.Id == employee.Id, employee);
                return employee;

            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee        
        public bool DeleteEmployee(string id)
        {
            try
            {
                //FilterDefinition<Employee> employeeData = Builders<Employee>.Filter.Eq("Id", id);
                db.Employees.DeleteOne(e => e.Id == id);
                return true;
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
