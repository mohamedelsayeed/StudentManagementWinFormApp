using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiApp.Repos
{
    class DepartmentRepo
    {
        public static DataTable getAll()
        {
            //return DBLayer.select("select * from Student");
            return DBLayer.select(" select[Dept_Id],[Dept_Name]  FROM Department");
        }
    }
}
