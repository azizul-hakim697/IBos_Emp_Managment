using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBosEmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = AttendanceService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Attendence Not Found");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = AttendanceService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Attendence Not Found");
            }
        }

        [HttpPost]
        public IActionResult Create(AttendanceDTO attendenceDTO)
        {
            var data = AttendanceService.Create(attendenceDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Please try again");
            }
        }
    }
}
