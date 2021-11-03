using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiApp.Repos
{
    class InstructorRepo
    {
        public static DataTable getAll()
        {
            //return DBLayer.select("select * from Student");
            return DBLayer.select("  select Ins_Id, Ins_Name FROM Instructor");
        }
    }
}
