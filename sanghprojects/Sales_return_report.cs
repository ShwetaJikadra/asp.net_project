using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sanghprojects
{
    public partial class Sales_return_master : Form
    {
        public Sales_return_master()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            this.Close();
        }
    }
}
