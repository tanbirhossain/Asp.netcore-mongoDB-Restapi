using Microsoft.AspNetCore.Mvc;
using MongoDB.Model;
using MongoDB.Repository;
using System.Collections.Generic;

namespace MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IEmployeeRepository objemployee;
        public ValuesController(IEmployeeRepository employeeRepository)
        {
            objemployee = employeeRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return objemployee.GetAllEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
