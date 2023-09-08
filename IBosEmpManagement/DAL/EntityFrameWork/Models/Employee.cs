using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork.Models
{
    public class Employee
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeId must be a positive integer.")]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "EmployeeName must be between 2 and 100 characters.")]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "EmployeeCode must be between 3 and 20 characters.")]
        public string EmployeeCode { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "EmployeeSalary must be a positive number.")]
        public decimal EmployeeSalary { get; set; }

        public int? SupervisorId { get; set; } // Use nullable int for employees with no supervisor

      public ICollection<Attendance> Attendance { get; set;}
    }
}
