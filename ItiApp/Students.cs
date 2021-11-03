using ItiApp.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItiApp
{
    public partial class Students : Form
    {
        int globalid = 0;
        public void clear(Control control)
        {
            foreach (var c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedItem = "";
                    ((ComboBox)c).Text = "";
                }
            }
        }

        public Students()
        {
            InitializeComponent();
            DataTable studentsdataTable = StudentRepo.getAll();
            DVGStudent.DataSource = studentsdataTable;

            DataTable dept = DepartmentRepo.getAll();
            comDepartment.DataSource = dept;
            comDepartment.DisplayMember = "Dept_Name";
            comDepartment.ValueMember = "Dept_Id";

            DataTable supervisors = InstructorRepo.getAll();
            comSupervisor.DataSource = supervisors;
            comSupervisor.DisplayMember = "Ins_Name";
            comSupervisor.ValueMember = "Ins_Id";
        }



        private void DVGStudent_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblstatus.Text = "";

            globalid = int.Parse(DVGStudent.SelectedRows[0].Cells[0].Value.ToString());
            txtfname.Text = DVGStudent.SelectedRows[0].Cells[1].Value.ToString();
            txtlname.Text = DVGStudent.SelectedRows[0].Cells[2].Value.ToString();
            txtAge.Text = DVGStudent.SelectedRows[0].Cells[4].Value.ToString();
            txtAddress.Text = DVGStudent.SelectedRows[0].Cells[3].Value.ToString();


            comDepartment.SelectedItem = int.Parse(DVGStudent.SelectedRows[0].Cells[6].Value.ToString());
            comDepartment.Text = DVGStudent.SelectedRows[0].Cells[5].Value.ToString();

            comSupervisor.Text = DVGStudent.SelectedRows[0].Cells[7].Value.ToString();
            comSupervisor.SelectedItem = int.Parse(DVGStudent.SelectedRows[0].Cells[8].Value.ToString());


            btnAdd.Enabled = false;
            btnAdd.Visible = false;
        }

        private void btnUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            string fname = txtfname.Text;
            string lname = txtlname.Text;
            string address = txtAddress.Text;
            int age = txtAge.Text != null ? int.Parse(txtAge.Text) : 0;
            int id = globalid;

            int depid = int.Parse(comDepartment.SelectedValue.ToString());
            int superid = int.Parse(comSupervisor.SelectedValue.ToString());

            int rowaffected = StudentRepo.update(id, fname, lname, address, age, depid, superid);
            if (rowaffected > 0)
            {
                DataTable studentsdataTable = StudentRepo.getAll();
                DVGStudent.DataSource = studentsdataTable;

                btnAdd.Enabled = true;
                btnAdd.Visible = true;
                lblstatus.Text = "Updated";
                globalid = 0;
                clear(this);
            }
            else
            {
                lblstatus.Text = "failed to update";

            }
        }

        private void btnDelete_MouseClick(object sender, MouseEventArgs e)
        {
            int id = globalid;

            int rowaffected = StudentRepo.delete(id);
            if (rowaffected > 0)
            {
                DataTable studentsdataTable = StudentRepo.getAll();
                DVGStudent.DataSource = studentsdataTable;
                lblstatus.Text = "Deleted";
                globalid = 0;
                clear(this);
            }
            else
            {
                lblstatus.Text = "failed to Delete";
            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fname = txtfname.Text;
            string lname = txtlname.Text;
            string address = txtAddress.Text;
            int age = txtAge.Text != null ? int.Parse(txtAge.Text) : 0;
            int id = globalid;

            int depid = int.Parse(comDepartment.SelectedValue.ToString());
            int superid = int.Parse(comSupervisor.SelectedValue.ToString());
            int rowaffected = StudentRepo.add( fname, lname, address, age, depid, superid);
            if (rowaffected > 0)
            {
                DataTable studentsdataTable = StudentRepo.getAll();
                DVGStudent.DataSource = studentsdataTable;

              
                lblstatus.Text = "added";
                globalid = 0;
                clear(this);
            }
            else
            {
                lblstatus.Text = "failed to add";

            }
        }
    }
}
