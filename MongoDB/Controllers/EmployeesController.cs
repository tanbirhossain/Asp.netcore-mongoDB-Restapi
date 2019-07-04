using Microsoft.AspNetCore.Mvc;
using MongoDB.Model;
using MongoDB.Repository;
using System.Collections.Generic;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> GetEmployeeList()
        {
            return _employeeRepository.GetAllEmployees();
        }
        [HttpGet("{id}")]
        public Employee GetEmployee(string id)
        {
            return _employeeRepository.GetEmployeeData(id);
        }
        [HttpPost]
        public Employee PostEmployee([FromBody] Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }
        [HttpPut("{id}")]
        public Employee PostEmployee(string id, [FromBody] Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }

        [HttpDelete("{id}")]
        public bool DeleteEmployee(string id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
        /// <summary>
        /// employee address add by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [Route("~/api/address/{id}")]
        [HttpPost]
        public Employee PostAddressById(string id, [FromBody] Address address)
        {


            return _employeeRepository.InsertAdderssByCustomerId(id, address);
        }
        [Route("~/api/address/{id}")]
        [HttpPut]
        public Employee AddressUpdateByCustomerId(string id, [FromBody] Address address)
        {

            return _employeeRepository.UpdateAdderssByCustomerId(id, address);
        }

        [Route("~/api/address/{name}")]
        [HttpGet]
        public Employee FindAddress(string name)
        {

            return _employeeRepository.GetAdderssByAddrssName(name);
        }
    }
}