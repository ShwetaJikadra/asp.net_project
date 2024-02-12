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
    public partial class Contact_Us : Form
    {
        public Contact_Us()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            this.Close();
        }

        private void Contact_Us_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("d");
            label9.Text = System.DateTime.Now.ToString("t");
        }
    }
}
