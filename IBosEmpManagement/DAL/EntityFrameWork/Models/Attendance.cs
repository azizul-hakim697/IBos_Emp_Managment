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
        public int EmployeeId { get; set; }
        public DateTime AttendenceDate { get; set; }
        public int IsPresent { get; set; }
        public int IsAbsent { get; set; }
        public int IsOffday { get; set; }
        public virtual Employee Employee { get; set; }

        // public virtual Employee Employee { get; set; }

    }
}
