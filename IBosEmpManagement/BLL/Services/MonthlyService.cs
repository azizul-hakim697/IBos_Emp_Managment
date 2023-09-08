using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MonthlyService
    {
        public List<MonthlyAttendanceDTO> GetMonthlyReport()
        {
            var reports = new List<MonthlyAttendanceDTO>();

            // Assuming you have a database context called 'db'
            var employees = DataAccessFactory.EmployeeData().Get();

            foreach (var employee in employees)
            {
                // Retrieve the attendance records for the employee for a specific month (e.g., September)
                var attendanceRecords = DataAccessFactory.AttendanceData().Get()
                    .Where(a => a.EmployeeId == employee.EmployeeId && a.AttendenceDate.Month == DateTime.Now.Month)
                    .ToList();

                // Calculate the report data
                var report = new MonthlyAttendanceDTO
                {
                    EmployeeName = employee.EmployeeName,
                    MonthName = DateTime.Now.ToString("MMMM"), // Replace with the actual month name
                    PayableSalary = (int)employee.EmployeeSalary, // Replace with the actual logic for calculating payable salary
                    TotalPresent = attendanceRecords.Count(a => a.IsPresent == 1),
                    TotalAbsent = attendanceRecords.Count(a => a.IsAbsent == 1),
                    TotalOffday = attendanceRecords.Count(a => a.IsOffday == 1),
                };

                reports.Add(report);
            }

            return reports;
        }
    }
}
