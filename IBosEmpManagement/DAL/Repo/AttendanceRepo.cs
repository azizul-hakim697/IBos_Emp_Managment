using DAL.EntityFrameWork.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AttendanceRepo : Repo, IRepo<Attendance, int, bool>
    {
        public bool Create(Attendance obj)
        {
            db.Attendances.Add(obj);
            return db.SaveChanges() > 0;
        }

        public List<Attendance> Get()
        {
            return db.Attendances.ToList();
        }

        public Attendance Get(int id)
        {
            return db.Attendances.Find(id);
        }

        public Attendance Get3rd()
        {
            throw new NotImplementedException();
        }

        public List<Attendance> GetOnAbsent()
        {
            throw new NotImplementedException();
        }

        List<string> IRepo<Attendance, int, bool>.GetOnHierarchy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Attendance obj)
        {
            throw new NotImplementedException();
        }
    }
}

