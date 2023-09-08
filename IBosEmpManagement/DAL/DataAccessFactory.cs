using DAL.EntityFrameWork.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepo();
        }

        public static IRepo<Attendance, int, bool> AttendanceData()
        {
            return new AttendanceRepo();
        }

    }
}
