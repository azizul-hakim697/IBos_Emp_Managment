using DAL.EntityFrameWork.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class EmployeeRepo : Repo, IRepo<Employee, int, bool>
    {
        public bool Create(Employee obj)
        {
            db.Employees.Add( obj);
            return db.SaveChanges()>0;
        }

        public List<Employee> Get()
        {
           return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Get3rd()
        {   
            return db.Employees
            .OrderByDescending(e =>e. EmployeeSalary)
                .Skip(2)
                .Take(1)
                .FirstOrDefault();
        }

        public List<Employee> GetOnAbsent()
        {
            var employeesWithNoAbsentRecords = db.Employees
           .Where(employee =>
               employee.Attendance.All(attendance => attendance.IsAbsent == 0)
           )
           .OrderByDescending(employee => employee.EmployeeSalary)
           .ToList();

            return employeesWithNoAbsentRecords;
        }

        public bool Update(Employee obj)
        {
            var exObj = Get(obj.EmployeeId);
            if (exObj == null)
            {
                return false;
            }
            exObj.EmployeeName = obj.EmployeeName;
            exObj.EmployeeCode = obj.EmployeeCode;

            db.Employees.Update(exObj);
            return db.SaveChanges() > 0;
        }

        List<string> IRepo<Employee, int, bool>.GetOnHierarchy(int id)
        {
            var hierarchy = new List<string>();

            while (id != 0)
            {
                var employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    // Employee not found
                    return null;
                }

                hierarchy.Add(employee.EmployeeName);

                // Check if SupervisorId is not null before assigning it to id
                if (employee.SupervisorId.HasValue)
                {
                    id = employee.SupervisorId.Value;
                }
                else
                {
                    // Handle the case where SupervisorId is null (if needed)
                    // You can break out of the loop or handle it according to your requirements.
                    // For example, you can throw an exception, return an error, or break the loop.
                    // Here, we'll break the loop.
                    break;
                }
            }

            hierarchy.Reverse(); // Reverse the hierarchy to get the correct order
            return hierarchy;
        }


    }
}
