using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace sanghprojects
{
    public partial class change_password : Form
    {

        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        OleDbConnection con;
        OleDbCommand cmd;
        public change_password()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox4.Text)
            {
                con = new OleDbConnection(s);
                con.Open();
                string s1 = "update login_tab set pwd='" + textBox3.Text + "' where unm='" + textBox1.Text + "'";
                cmd = new OleDbCommand(s1, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password update success");
            }
        }

        private void change_password_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("d");
            label12.Text = System.DateTime.Now.ToString("t");
        }
    }
}
