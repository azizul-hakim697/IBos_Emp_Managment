using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<CLASS,ID,RET>
    {
        RET Update(CLASS obj);//api1

        CLASS Get3rd();//api2

        List<CLASS> GetOnAbsent();//api3

        //List<CLASS> GetMonthlyAttendence();//api4

        List<string> GetOnHierarchy(ID id);//api4

        List<CLASS> Get();

        CLASS Get(ID id);

        RET Create(CLASS obj);

    }
}
