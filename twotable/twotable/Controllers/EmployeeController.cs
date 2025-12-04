using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twotable.Models;
using twotable.Services;

namespace twotable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //GET : api/EmployeeController
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeService.GetAllEmployee();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var emp = employeeService.GetEmployee(id);

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            employeeService.Add(emp);
            return CreatedAtAction("Get", new { id = emp.Id }, emp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            emp.Id = id;

            var updated = employeeService.Update(emp);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }



        [HttpDelete("{id}")]
        public void delete(int id)
        {
            Employee e = employeeService.GetEmployee(id);
            if (e != null)
            {
                employeeService.Delete(id);
            }
        }
    }
}
