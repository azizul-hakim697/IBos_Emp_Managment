using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.DTOs;
using DAL.EntityFrameWork.Models;
using Newtonsoft.Json;

namespace BLL.Services
{
    public class AttendanceService
    {
        public static List<AttendanceDTO> Get()
        {
            var data = DataAccessFactory.AttendanceData().Get();
            var config = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<AttendanceDTO>>(data);
            return converted;
        }


        public static AttendanceDTO Get(int id)
        {
            var data = DataAccessFactory.AttendanceData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var converted = JsonConvert.DeserializeObject<AttendanceDTO>(JsonConvert.SerializeObject(data, jsonSettings));

            return converted;
        }


        public static AttendanceDTO Create(AttendanceDTO attendenceDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AttendanceDTO, Attendance>();
                cfg.CreateMap<Attendance, AttendanceDTO>();
            });
            var mapper = new Mapper(config);

            var attendence = mapper.Map<Attendance>(attendenceDTO);

            var isSuccess = DataAccessFactory.AttendanceData().Create(attendence);

            if (isSuccess)
            {
                var createAttendence = DataAccessFactory.AttendanceData().Get(attendence.Id);

                var createAttendenceDTO = mapper.Map<AttendanceDTO>(createAttendence);

                return createAttendenceDTO;
            }
            else
            {
                return null;
            }
        }
        }

    
}
