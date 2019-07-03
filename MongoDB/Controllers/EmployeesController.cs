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
        private readonly IEmployeeRepository objemployee;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            objemployee = employeeRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return objemployee.GetAllEmployees();
        }
    }
}