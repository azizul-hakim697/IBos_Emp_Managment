using DAL.EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class Repo
    {
        public IBosEmpContext db;

            public Repo() 
                {
            // Set up DbContextOptions for in-memory database
            var options = new DbContextOptionsBuilder<IBosEmpContext>()
                .UseInMemoryDatabase(databaseName: "Employee")
                .Options;

            db = new IBosEmpContext(options);

        }
    }
}
