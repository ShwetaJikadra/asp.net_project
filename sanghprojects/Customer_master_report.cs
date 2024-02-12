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
    public partial class Customer_master_report : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb");
        DataTable dt;
        OleDbCommand cmd;
        OleDbDataAdapter da;

        public Customer_master_report()
        {
            InitializeComponent();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Want To Exit...", "Exit..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Customer_master_report_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("d");
            label5.Text = System.DateTime.Now.ToString("t");

            radioButton1.Checked = false;
            da = new OleDbDataAdapter();
            cmd = new OleDbCommand("select * from cust_mstr_tbl", cn);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "cust_mstr_tbl";
            comboBox4.ValueMember = "Cust_id";

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "cust_mstr_tbl";
            comboBox3.ValueMember = "Cust_nm";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                axCrystalReport1.WindowShowRefreshBtn = true;
                string st;

                if (radioButton3.Checked)
                {
                    st = Application.StartupPath + "\\report\\cust_report.rpt";
                    axCrystalReport1.SelectionFormula = "{cust_mstr_tbl.Cust_id}=" + comboBox4.Text + "";
                    axCrystalReport1.ReportFileName = st;
                }

                else if (radioButton2.Checked)
                {
                    st = Application.StartupPath + "\\report\\cust_report.rpt";
                    axCrystalReport1.SelectionFormula = "{cust_mstr_tbl.Cust_nm}='" + comboBox3.Text + "'";
                    axCrystalReport1.ReportFileName = st;
                }
                else
                {
                    st = Application.StartupPath + "\\report\\cust_report.rpt";
                    axCrystalReport1.SelectionFormula = "{cust_mstr_tbl.Cust_id}>0";
                    axCrystalReport1.ReportFileName = st;
                }
                axCrystalReport1.Connect = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\shwet\Desktop\database_pro\db.mdb";
                axCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized;
                axCrystalReport1.WindowShowRefreshBtn = true;
                axCrystalReport1.Refresh();
                axCrystalReport1.Action = 1;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox3.Visible = true;
                comboBox4.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox4.Visible = true;
                comboBox3.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
