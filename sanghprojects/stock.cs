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
    public partial class stock : Form
    {

        OleDbConnection con;
        DataTable tb = new DataTable();
        OleDbCommand cmd;

        OleDbDataReader dr;

        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";

        public stock()
        {
            InitializeComponent();
        }

        public void display()
        {
            con.Open();
            cmd = new OleDbCommand("select * from stock_tbl", con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void stock_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection(s);
            label1.Text = DateTime.Now.ToString("d");
            label5.Text = DateTime.Now.ToString("T");
            radioButton1.Checked = false;
            display();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Items.Clear();
            if (radioButton3.Checked)
            {
                comboBox1.Visible = true;
                con = new OleDbConnection(s);
                con.Open();
                cmd = new OleDbCommand("select distinct pro_id from stock_tbl", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox4.Items.Add(dr[0].ToString());
                con.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("select * from stock_tbl where pro_id=" + comboBox4.Text + "", con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Exit This window?", "Exit login", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                // System.Environment.Exit(0);
                this.Close();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox4.Text = "";
            comboBox3.Items.Clear();
            if (radioButton2.Checked)
            {
                comboBox3.Visible = true;
                con = new OleDbConnection(s);
                con.Open();
                cmd = new OleDbCommand("select  distinct pro_name from stock_tbl", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    comboBox3.Items.Add(dr[0].ToString());
                con.Close();


            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("select * from stock_tbl where pro_name='" + comboBox3.Text + "'", con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            display();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Text = "";

            comboBox3.Text = "";

            comboBox1.Text = "";
            display();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
              comboBox4.Text="";
                  comboBox3.Text="";
             comboBox1.Items.Clear();
             if (radioButton4.Checked)
             {
                 comboBox1.Visible = true;
                 con = new OleDbConnection(s);
                 con.Open();
                 cmd = new OleDbCommand("select  distinct pro_type from stock_tbl", con);
                 dr = cmd.ExecuteReader();
                 while (dr.Read())
                     comboBox1.Items.Add(dr[0].ToString());
                 con.Close();
             }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("select *  from stock_tbl where pro_type='" + comboBox1.Text + "'", con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
