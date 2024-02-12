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
    public partial class stock_report : Form
    {

        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb");
        DataTable dt;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        public stock_report()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            comboBox3.Visible = false;
            comboBox1.Visible = false;
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                axCrystalReport1.WindowShowRefreshBtn = true;
                string st;

                if (radioButton3.Checked)
                {
                    st = Application.StartupPath + "\\report\\stk_report.rpt";
                    axCrystalReport1.SelectionFormula = "{stock_tbl.pro_type}='" + comboBox3.Text + "'";
                    axCrystalReport1.ReportFileName = st;
                }

                else if (radioButton2.Checked)
                {
                    st = Application.StartupPath + "\\report\\stk_report.rpt";
                    axCrystalReport1.SelectionFormula = "{stock_tbl.pro_name}='" + comboBox2.Text + "'";
                    axCrystalReport1.ReportFileName = st;
                }
                else if(radioButton1.Checked)
                {
                    st = Application.StartupPath + "\\report\\stk_report.rpt";
                    axCrystalReport1.SelectionFormula = "{stock_tbl.pro_id}="+comboBox1.Text+"";
                    axCrystalReport1.ReportFileName = st;
                }
                axCrystalReport1.Connect = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
                axCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized;
                axCrystalReport1.WindowShowRefreshBtn = true;
                axCrystalReport1.Refresh();
                axCrystalReport1.Action = 1;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Want To Exit...", "Exit..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void stock_report_Load(object sender, EventArgs e)
        {

            label1.Text = System.DateTime.Now.ToString("d");
            label11.Text = System.DateTime.Now.ToString("t");
            radioButton3.Checked = true;
            da = new OleDbDataAdapter();
            cmd = new OleDbCommand("select * from stock_tbl", cn);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "stock_tbl";
            comboBox1.ValueMember = "pro_id";

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "stock_tbl";
            comboBox2.ValueMember = "pro_name";

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "stock_tbl";
            comboBox3.ValueMember = "pro_type";
        }
    }
}
