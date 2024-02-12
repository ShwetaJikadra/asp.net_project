﻿using System;
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
    public partial class Purchage_return_report : Form
    {

        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb");
        DataTable dt;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        public Purchage_return_report()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Purchage_return_report_Load(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Now.ToString("d");
            label5.Text = System.DateTime.Now.ToString("t");

            radioButton3.Checked = true;
           

            radioButton1.Checked = false;
            da = new OleDbDataAdapter();
            cmd = new OleDbCommand("select * from pur_ret_tbl", cn);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "pur_ret_tbl";
            comboBox4.ValueMember = "pur_r_id";

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "pur_ret_tbls";
            comboBox3.ValueMember = "pro_name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                axCrystalReport1.WindowShowRefreshBtn = true;
                string st;

                if (radioButton3.Checked)
                {
                    st = Application.StartupPath + "\\report\\pur_r_report.rpt";
                    axCrystalReport1.SelectionFormula = "{pur_ret_tbl.pur_r_id}=" + comboBox4.Text + "";
                    axCrystalReport1.ReportFileName = st;
                }

                else if (radioButton2.Checked)
                {
                    st = Application.StartupPath + "\\report\\pur_r_report.rpt";
                    axCrystalReport1.SelectionFormula = "{pur_ret_tbl.pro_name}='" + comboBox3.Text + "'";
                    axCrystalReport1.ReportFileName = st;
                }
                else
                {
                    st = Application.StartupPath + "\\report\\pur_r_report.rpt";
                    axCrystalReport1.SelectionFormula = "{pur_ret_tbl.pur_r_id}>0";
                    axCrystalReport1.ReportFileName = st;
                }
                axCrystalReport1.Connect = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\group-2\database_pro\db.mdb";
                axCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized;
                axCrystalReport1.WindowShowRefreshBtn = true;
                axCrystalReport1.Refresh();
                axCrystalReport1.Action = 1;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
            }
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
    }
}
