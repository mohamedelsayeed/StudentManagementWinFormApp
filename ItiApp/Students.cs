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
        public Students()
        {
            InitializeComponent();
            DataTable studentsdataTable = StudentRepo.getAll();
            DVGStudent.DataSource = studentsdataTable;
        }


    }
}
