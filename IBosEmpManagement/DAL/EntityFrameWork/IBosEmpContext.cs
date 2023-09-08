using DAL.EntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork  
{
    public class IBosEmpContext : DbContext
    {
        public IBosEmpContext()
        {
        }

        public IBosEmpContext(DbContextOptions options) : base(options)
        {
        }

        
        public DbSet<Employee>Employees { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
    }
}
