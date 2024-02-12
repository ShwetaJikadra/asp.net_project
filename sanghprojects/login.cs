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
    public partial class login : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public login()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("D");
            label5.Text = System.DateTime.Now.ToString("t");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // String usr = textBox1.Text;
         //   String pwd = textBox2.Text;
            con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from login_tab where unm='"+textBox1.Text+"' and pwd='"+textBox2.Text+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mdi m1 = new mdi();
                m1.Show();

            }
            else
            {
                MessageBox.Show("incorrect user name and password!!!");
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
