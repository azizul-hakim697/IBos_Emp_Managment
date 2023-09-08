using AutoMapper;
using BLL.DTOs;
using DAL;

using DAL.EntityFrameWork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmployeeDTO>>(data);
            return converted;
        }

        public static EmployeeDTO Get(int id)
        {
            var data = DataAccessFactory.EmployeeData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmployeeDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }

        public static EmployeeDTO Create(EmployeeDTO employee)
        {
            var existingEmployees = DataAccessFactory.EmployeeData().Get();

            if (existingEmployees != null && existingEmployees.Any())
            {
                int maxEmployeeId = existingEmployees.Max(x => x.EmployeeId);
                employee.EmployeeId = maxEmployeeId + 1;
            }
            else
            {
                
                employee.EmployeeId = 502030;
            }

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var emp = mapper.Map<Employee>(employee);

            var isSuccess = DataAccessFactory.EmployeeData().Create(emp);

            if (isSuccess)
            {
                var createEmployee = DataAccessFactory.EmployeeData().Get(emp.EmployeeId);

                var createEmpDTO = mapper.Map<EmployeeDTO>(createEmployee);

                return createEmpDTO;
            }
            else
            {
                return null;
            }
        }

        public static bool Update(EmployeeDTO employee)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var emp = mapper.Map<Employee>(employee);

            var isSuccess = DataAccessFactory.EmployeeData().Update(emp);

            return isSuccess;
        }

        public static List<EmployeeDTO> GetOnAbsent()
        {
            var data = DataAccessFactory.EmployeeData().GetOnAbsent();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<EmployeeDTO>>(data);
            return converted;
        }

        public static EmployeeDTO Get3rd()
        {
            var data = DataAccessFactory.EmployeeData().Get3rd();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<EmployeeDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }

        public static List<string> GetEmployeeHierarchy(int id)
        {
            return DataAccessFactory.EmployeeData().GetOnHierarchy(id);
        }

    }
}
