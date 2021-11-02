using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ItiApp
{
    public partial class login : Form
    {
        SqlConnection con;

        public login()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var admin  = AdminRepo.getAdminByUserandPass(username, password);
                if(admin != null)
                {
                    Console.WriteLine("found");
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
        }
    }
}
