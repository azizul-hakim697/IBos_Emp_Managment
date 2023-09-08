using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBosEmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController  : Controller
    {
        // GET: api/employees
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = EmployeeService.Get();
            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> Get(int id)
        {
            var employee = EmployeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public ActionResult<EmployeeDTO> Post([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployee = EmployeeService.Create(employee);

            if (createdEmployee == null)
            {
                return BadRequest("Failed to create employee.");
            }

            return CreatedAtAction("Get", new { id = createdEmployee.EmployeeId }, createdEmployee);
        }


        // PUT: api/employees/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDTO employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest("Employee ID in the request does not match the route parameter.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isSuccess = EmployeeService.Update(employee);

            if (isSuccess)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to update employee.");
            }
        }

        // GET: api/employees/absent
        [HttpGet("absent")]
        public ActionResult<IEnumerable<EmployeeDTO>> GetOnAbsent()
        {
            var employees = EmployeeService.GetOnAbsent();
            return Ok(employees);
        }


        // GET: api/employees/3rd
        [HttpGet("third")]
        public ActionResult<EmployeeDTO> Get3rd()
        {
            var employee = EmployeeService.Get3rd();
            return Ok(employee);
        }


        // GET: api/employees/hierarchy/5
        [HttpGet("hierarchy/{id}")]
        public ActionResult<IEnumerable<string>> GetEmployeeHierarchy(int id)
        {
            var hierarchy = EmployeeService.GetEmployeeHierarchy(id);
            return Ok(hierarchy);
        }


    }
}
