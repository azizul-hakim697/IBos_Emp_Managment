using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork.Models
{
    public class Attendance
    {   
        
        public int Id { get; set; }

        [ForeignKey("Employee")]
        [Required(ErrorMessage = "EmployeeId is required.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "AttendanceDate is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AttendanceDate { get; set; }

        [Range(0, 1, ErrorMessage = "IsPresent must be either 0 (absent) or 1 (present).")]
        public int IsPresent { get; set; }

        [Range(0, 1, ErrorMessage = "IsAbsent must be either 0 (not absent) or 1 (absent).")]
        public int IsAbsent { get; set; }

        [Range(0, 1, ErrorMessage = "IsOffday must be either 0 (not an off day) or 1 (off day).")]
        public int IsOffday { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
