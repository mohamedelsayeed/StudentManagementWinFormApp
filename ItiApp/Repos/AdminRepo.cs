using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiApp
{
    class AdminRepo
    {
        public static DataTable getAdminByUserandPass(string username, string password)
        {
            return DBLayer.select($"select * from AdminUser where Username = '{username}' and Password = '{password}'");
        }
    }
}
