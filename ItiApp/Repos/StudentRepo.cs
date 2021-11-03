using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiApp
{
    class StudentRepo
    {

        public static DataTable getAll()
        {
            //return DBLayer.select("select * from Student");
            return DBLayer.select(" select std.St_Id, std.St_Fname, std.St_Lname, std.St_Address, std.St_Age,   " +
                            "     dep.Dept_Name, dep.Dept_Id, ins.Ins_Name, ins.Ins_Id   " +
                            "    from Student std, Department dep , Instructor ins " +
                            " where std.Dept_Id = dep.Dept_Id and std.St_super = ins.Ins_Id");
        }


        public static int update(int id, string fname, string lname, string address, int age, int depid, int superId)
        {
            return DBLayer.dml($"update Student set St_Fname = '{fname}' , St_Lname = '{lname}' " +
                        $", St_Address = '{address}' , St_Age = {age}, Dept_Id = {depid}, St_super = {superId} where St_Id = {id} ");

        }

        public static int delete(int id)
        {
            return DBLayer.dml($"delete from Student where St_Id = {id}");
        }

        public static int add(string fname, string lname, string address, int age, int depid, int superId)
        {
            return DBLayer.dml($"insert into Student values ('{fname}' , '{lname}', '{address}' , {age} , {depid} , {superId})");
        }

    }

    //  St_Id
    //  St_Fname
    //  St_Lname
    //  St_Address
    //  St_Age
    //  Dept_Id
    //  St_super
}
