using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBosEmpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyReportController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMonthlyReport()
        {
            var monthlyService = new MonthlyService();
            var data = monthlyService.GetMonthlyReport();

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
