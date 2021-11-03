  select * from AdminUser where Username = 'admin' and Password = '123'


  select std.St_Id, std.St_Fname, std.St_Lname, std.St_Address, std.St_Age,
		dep.Dept_Name, dep.Dept_Id, ins.Ins_Name, ins.Ins_Id
	   from Student std, Department dep , Instructor ins
  where std.Dept_Id = dep.Dept_Id and std.St_super = ins.Ins_Id