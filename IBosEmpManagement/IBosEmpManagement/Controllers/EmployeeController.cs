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
        [HttpGet("allemp")]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = EmployeeService.Get();
            return Ok(employees);
        }

        // GET: api/employees/id
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

        // POST: api/employees/create
        [HttpPost("Createemp")]
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



        //update
        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeDTO employeeDTO)
        {
            employeeDTO.EmployeeId = id;

            var isSuccess = EmployeeService.Update(employeeDTO);

            if (isSuccess)
            {
                return Ok("Updated :)");
            }
            else
            {
                return BadRequest("Please try again");
            }
        }

        //get 3rd highest salary
        [HttpGet("3rdhighsal")]
        public IActionResult ThirdHighestSal()
        {
            var data = EmployeeService.Get3rd();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Nor Record Found!");
            }
        }

        // GET: api/employees/absent
        [HttpGet("absent")]
        public IActionResult GetOnAbcent()
        {
            var data = EmployeeService.GetOnAbsent();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Record Found!");
            }
        }




        // GET: api/employees/hierarchy/5
        [HttpGet("hierarchy/{id}")]
        public ActionResult<IEnumerable<string>> GetEmployeeHierarchy(int id)
        {
            var hierarchy = EmployeeService.GetEmployeeHierarchy(id);
            return Ok(hierarchy);
        }

        [HttpGet]
        public IActionResult GetByHierarchy(int id)
        {
            var data = EmployeeService.GetEmployeeHierarchy(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Record Found!");
            }
        }

    }
}
