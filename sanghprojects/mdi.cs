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
    public partial class mdi : Form
    {
        public mdi()
        {
            InitializeComponent();
        }

        private void sellToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void stokeInToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stokeInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void customerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void returnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
           
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compony_master cm = new compony_master();
            cm.Show();

            
        }

        private void productMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            product_mstrs pm = new product_mstrs();
            pm.Show();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cust_master cum = new cust_master();
            cum.Show();
        
           
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            change_password cp = new change_password();
            cp.Show();
        }

        private void purchageEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Purchage_entry pe = new Purchage_entry();
            pe.Show();
          

        }

        private void ChangeEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_entry se = new Sales_entry();
            se.Show();
          
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Sales_return_report_form srf = new Sales_return_report_form();
            srf.Show();
           
        }

        private void productMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_master_report promr = new Product_master_report();
            promr.Show();
         
        }

        private void companyMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Company_master_report cmr = new Company_master_report();
            cmr.Show();
         

        }

        private void customerMasterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_master_report cumr = new Customer_master_report();
            cumr.Show();
           
        }

        private void purchageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchage_master_report purmr = new Purchage_master_report();
            purmr.Show();
         
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_master_report smr = new Sales_master_report();
            smr.Show();
          
        }

        private void purchageReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchage_return_report purrr = new Purchage_return_report();
            purrr.Show();
          
        }

        private void salesReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales_return_reportt srr = new sales_return_reportt();
            srr.Show();
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Contact_Us conus = new Contact_Us();
            conus.Show();
         
        }

        private void salesOrdecustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
         
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\notepad.exe");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\calc.exe");
        }

        private void mdi_Load(object sender, EventArgs e)
        {

        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       

        private void salesEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_entry se = new Sales_entry();
            se.Show();
           
        }

        private void eXITToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure Exit This Window ?", "Exit Login", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                System.Environment.Exit(0);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Purchage_return_form prf = new Purchage_return_form();
            prf.Show();
        }

        private void stockDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock stk = new stock();
            stk.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            login lb = new login();
            lb.Show();
            
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock_report sr = new stock_report();
            sr.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
