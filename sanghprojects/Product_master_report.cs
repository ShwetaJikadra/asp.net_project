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
    public partial class Product_master_report : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb");
        DataTable dt;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        public Product_master_report()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Want To Exit...", "Exit..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Product_master_report_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("d");
            label6.Text = System.DateTime.Now.ToString("t");
            radioButton3.Checked = true;
            da = new OleDbDataAdapter();
            cmd = new OleDbCommand("select * from product_mstr_tbl", cn);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
           comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "product_mstr_tbl";
           comboBox3.ValueMember = "pro_id";

           comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "product_mstr_tbl";
            comboBox4.ValueMember = "pro_name";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox3.Visible = true;
                comboBox4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                axCrystalReport1.WindowShowRefreshBtn = true;
                string st;

                if (radioButton1.Checked)
                {
                    st = Application.StartupPath + "\\report\\pro_report.rpt";
                    axCrystalReport1.SelectionFormula = "{product_mstr_tbl.pro_id}=" + comboBox3.Text + "";
                    axCrystalReport1.ReportFileName = st;
                }

                else if (radioButton2.Checked)
                {
                    st = Application.StartupPath + "\\report\\pro_report.rpt";
                    axCrystalReport1.SelectionFormula = "{product_mstr_tbl.pro_name}='" + comboBox4.Text + "'";
                    axCrystalReport1.ReportFileName = st;
                }
                else
                {
                    st = Application.StartupPath + "\\report\\pro_report.rpt";
                    axCrystalReport1.SelectionFormula = "{product_mstr_tbl.pro_id}>0";
                    axCrystalReport1.ReportFileName = st;
                }
                axCrystalReport1.Connect = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
                axCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized;
                axCrystalReport1.WindowShowRefreshBtn = true;
                axCrystalReport1.Refresh();
                axCrystalReport1.Action = 1;
                comboBox4.Visible = false;
                comboBox3.Visible = false;
            }

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
               comboBox3.Visible = false;
               comboBox4.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void axCrystalReport1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            comboBox4.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
