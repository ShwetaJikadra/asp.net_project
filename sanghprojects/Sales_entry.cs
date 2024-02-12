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
    public partial class Sales_entry : Form
    {
        public Sales_entry()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        int pos = 0;
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
      
            
       int id;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
     
        private void button1_Click(object sender, EventArgs e)
        {

            //comboBox1.Text.ToString();
          
                       
           
        }
        public void display()
        {
            textBox4.Focus();
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from Sales_entry_tbls";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select Cust_nm from cust_mstr_tbl where Cust_id="+comboBox1.SelectedItem+"";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
           
            reader.Read();
            textBox6.Text = reader.GetValue(0).ToString();
        
         
            
           

                


      
            

           
            
            
            
        }
        public void showdata(int index)
        {
            comboBox1.Text = dt.Rows[index][0].ToString();
            textBox1.Text = dt.Rows[index][1].ToString();
            textBox2.Text = dt.Rows[index][2].ToString();
            comboBox5.Text = dt.Rows[index][3].ToString();
            textBox1.Text = dt.Rows[index][4].ToString();
            textBox2.Text = dt.Rows[index][5].ToString();
           comboBox9.Text = dt.Rows[index][6].ToString();
            dateTimePicker1.Text=dt.Rows[index][7].ToString();
            textBox9.Text = dt.Rows[index][8].ToString();
            textBox10.Text = dt.Rows[index][9].ToString();
            textBox11.Text = dt.Rows[index][10].ToString();
            textBox3.Text = dt.Rows[index][11].ToString();
            textBox12.Text = dt.Rows[index][12].ToString();

        }

        private void Sales_entry_Load(object sender, EventArgs e)
        {
            button11.Enabled = false;
            OleDbConnection c = new OleDbConnection(s);
            c.Open();
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from Sales_entry_tbls", c);
            adt.Fill(dt);
            c.Close();
           // textBox4.Focus();
            ActiveControl = textBox4;
          OleDbConnection con4 = new OleDbConnection(s);
          con4.Open();
            string s4 = "select  Cust_id from cust_mstr_tbl";
            OleDbCommand cmd4 = new OleDbCommand(s4, con4);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);
            
            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }
            con4.Close();
            //radio id

            OleDbConnection con = new OleDbConnection(s);
            con.Open();

            comboBox4.Visible = true;
            string s3 = "select  distinct Sales_bill_no from Sales_entry_tbls";
            OleDbCommand cmd3 = new OleDbCommand(s3, con);

            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da2.Fill(ds3);

            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
            }
            //con.Close();

            //radio  name

            comboBox3.Visible = true;
            string s5 = "select distinct Cust_nm from Sales_entry_tbls";
            OleDbCommand cmd5 = new OleDbCommand(s5, con);

            OleDbDataAdapter da5 = new OleDbDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);

            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
            }
           
         
            
            
            //customer id
       //     OleDbConnection con = new OleDbConnection(s);
          //  con.Open();
         /*   string s1 = "select distinct Cust_id from cust_mstr_tbl";
            OleDbCommand cmd = new OleDbCommand(s1, con);
       
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }*/

            //..................................................................
           //pro_id
            string s2 = "select distinct pro_id from pur_entry_tbl";
            OleDbCommand cmd1= new OleDbCommand(s2, con);

            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            DataSet ds1= new DataSet();
            da1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBox5.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
            }
            con.Close();

           }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
          
           
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
           
            
        }

        

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
           
          
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
           
               
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*
            if (textBox1.Text == "Furtilizers")
            {
                textBox3.Text="22";
            }
            if (textBox1.Text == "Beeds")
            {
                textBox3.Text = "18";
            }
            if (textBox1.Text == "Books")
            {
                textBox3.Text = "0";
            }
            if (textBox1.Text == "pesticide")
            {
                textBox3.Text = "18";
            }
            if (textBox1.Text=="Crackers")
            {
                textBox3.Text = "0";
            }
            */
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
       public void reset()
        {
          

                comboBox1.Text ="";
                textBox4.Text="";
                textBox6.Text = "";
                comboBox5.Text = "";
                textBox1.Text="";
                comboBox9.Text= "";
                textBox2.Text="";
                dateTimePicker1.Text = "";
                textBox9.Text="";
                textBox10.Text="";
                textBox11.Text="";
                textBox3.Text="";
                textBox12.Text="";

                textBox10.Text="";

                textBox3.Text="";
                textBox12.Text="";
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            display();
        }
        string qclear, qty2;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox9.Text == "" || dateTimePicker1.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox3.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("please select record in gridview");
            }
            else
            {

                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                qclear = textBox2.Text;
               OleDbCommand cmd = new OleDbCommand("select qtn from Sales_entry_tbls where pro_type='" + textBox2.Text + "'", con);
               OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = dr[0].ToString();
                }
                cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox2.Text+ "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty2 = dr[0].ToString();
                }
                tot = Convert.ToString(Convert.ToInt32(qty2) - Convert.ToInt32(qty1));
                cmd = new OleDbCommand("update stock_tbl set qty=" + tot + " where pro_type='" + textBox2.Text+ "'", con);
                cmd.ExecuteNonQuery();

                string str = "update Sales_entry_tbls set Cust_id=" + comboBox1.SelectedItem + ",Cust_nm='" + textBox6.Text + "',pro_id=" + comboBox5.SelectedItem + ",pro_name='" + textBox1.Text + "',pro_type='" + textBox2.Text + "',Sales_date='" + dateTimePicker1.Text + "',qtn=" + textBox9.Text + ",unit_price=" + textBox10.Text + ",total=" + textBox11.Text + ",gst=" + textBox3.Text + ",net_price=" + textBox12.Text + " where Sales_bill_no=" +id + "";
                 cmd = new OleDbCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Are you want to Edit record ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox2.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty1 = dr[0].ToString();
                }
                cmd = new OleDbCommand("select qtn from Sales_entry_tbls where pro_type='" + textBox2.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    qty2 = dr[0].ToString();
                }
                tot = Convert.ToString(Convert.ToInt32(qty1) + Convert.ToInt32(qty2));

                cmd = new OleDbCommand("update stock_tbl set qty=" + tot + " where pro_type='" + textBox2.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("stock updated.....");

                display();
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox9.SelectedItem == "" || dateTimePicker1.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox3.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("please select record in gridview");
            }
            else
            {

                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                OleDbCommand cmd = new OleDbCommand("delete Cust_id,Sales_bill_no,Cust_nm,pro_id,pro_name,pro_type,pay_type,Sales_date,qtn,unit_price,total,gst,net_price from Sales_entry_tbls where Sales_bill_no=" + id + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Record SuccessFully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                display();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox4.Visible = false;
                comboBox3.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                button11.Enabled = true;
                comboBox4.Visible = true;
                comboBox3.Visible = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox4.Visible = false;
                comboBox3.Visible = true;
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "select * from Sales_entry_tbls where Cust_nm='" + comboBox3.SelectedItem + "'";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("please perform sequentially");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                comboBox3.Visible = false;
                comboBox4.Visible = true;
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "select * from Sales_entry_tbls    where Sales_bill_no=" + comboBox4.SelectedItem + "";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception)
            {
               MessageBox.Show("perform sequentially");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
               comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox4.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               comboBox5.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
              //  dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            else
            {
                MessageBox.Show("must be select row");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select Cust_nm from cust_mstr_tbl where Cust_id=" + comboBox1.Text + "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            // DataTable dt = new DataTable();
            // dt.Load(reader);
            reader.Read();
            textBox6.Text = reader.GetValue(0).ToString();
           
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox9.Text);
            double b = Convert.ToDouble(textBox10.Text);
            double t = a * b;
            textBox11.Text = Convert.ToString(t);

            Convert.ToString(textBox9.Text);
            Convert.ToString(textBox10.Text);
            Convert.ToString(textBox11.Text);
           

        }

        private void button8_Click(object sender, EventArgs e)
        {

            pos++;
            if (pos < dt.Rows.Count)
            {
                showdata(pos);
            }
            else
            {
                MessageBox.Show("END of the record");
                pos = dt.Rows.Count - 1;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            try
            {
                double gst = Convert.ToDouble(textBox3.Text);
                double tot = Convert.ToDouble(textBox11.Text);
                double net = (tot * (gst / 100) + tot);
                textBox12.Text = Convert.ToString(net);
                Convert.ToString(textBox3.Text);
                Convert.ToString(textBox11.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
          
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select pro_name,pro_type,unit_price,gst from pur_entry_tbl where pro_id='" + comboBox5.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            // DataTable dt = new DataTable();
            // dt.Load(reader);
            reader.Read();
            textBox1.Text = reader.GetValue(0).ToString();
            textBox2.Text = reader.GetValue(1).ToString();
            textBox10.Text = reader.GetValue(2).ToString();
            textBox3.Text = reader.GetValue(3).ToString();

        }

        private void Sales_entry_Leave(object sender, EventArgs e)
        {

        }
        string q1, qty1;
        string tot;
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox9.Text == "" || dateTimePicker1.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox3.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("please enter required field");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection(s);
                OleDbCommand cmd;
                OleDbDataReader dr;
                conn.Open();



                string s1 = "select * from Sales_entry_tbls  where Sales_bill_no=" + textBox4.Text + "";
                OleDbCommand cmd1 = new OleDbCommand(s1, conn);
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd1);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("duplicate record not allow");
                    textBox4.Focus();
                }
                else
                {
                    q1 = textBox9.Text;

                    cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox2.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        qty1 = dr[0].ToString();
                    }
                    if (Convert.ToInt32(qty1) > 0)
                    {
                        string str = "insert into Sales_entry_tbls values(" + comboBox1.Text + ",'" + textBox6.Text + "'," + textBox4.Text + "," + comboBox5.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox9.Text + "','" + dateTimePicker1.Text + "'," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "," + textBox3.Text + "," + textBox12.Text + ")";
                        cmd = new OleDbCommand(str, conn);
                        cmd.ExecuteNonQuery();

                        tot = Convert.ToString(Convert.ToInt32(qty1) - Convert.ToInt32(q1));
                        Convert.ToInt32(tot);
                        cmd = new OleDbCommand("update stock_tbl set qty='" + tot + "' where pro_type='" + textBox2.Text + "'", conn);
                        cmd.ExecuteReader();
                        MessageBox.Show("stock updated...");
                        conn.Close();
                        display();
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("stock is not avilable.....");
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showdata(pos);
            }
            else
            {
                MessageBox.Show("First the record");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            pos = 0;
            showdata(pos);
        }

        private void button9_Click(object sender, EventArgs e)
        {

            pos = dt.Rows.Count - 1;
            showdata(pos);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string st = Application.StartupPath + "\\report\\bill_report.rpt";
            axCrystalReport1.ReportFileName = st;

            axCrystalReport1.SelectionFormula = "{ Sales_entry_tbls.Sales_bill_no}=" + comboBox4.Text + "";
            axCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized;
            axCrystalReport1.WindowShowRefreshBtn = true;
            axCrystalReport1.Action = 1;
        }

       /* private void button1_Click_1(object sender, EventArgs e)
        {
          /*  if (textBox1.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" || comboBox9.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox3.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("please enter required field");
            }
            else
            {

                Convert.ToInt32(q1);
                OleDbDataReader dr;

                qty1 = textBox9.Text;
                Convert.ToInt32(qty1);



                string s1 = "select * from Sales_entry_tbls where Sales_bill_no=" + textBox4.Text + "";
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                OleDbCommand cmd1 = new OleDbCommand(s1, con);
                OleDbDataAdapter adp = new OleDbDataAdapter(cmd1);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("duplicate record not allow");
                }
                else
                {
                    // OleDbConnection con1 = new OleDbConnection(s);
                    OleDbCommand cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox2.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        qty1 = dr[0].ToString();
                    }
                    if (Convert.ToInt32(qty1) > 0)
                    {


                        string str = "insert into Sales_entry_tbls values(" + comboBox1.Text + ",'" + textBox6.Text + "'," + textBox4.Text + "," + comboBox5.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox9.Text + "','" + dateTimePicker1.Text + "'," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "," + textBox3.Text + "," + textBox12.Text + ")";
                        cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("insert success");


                        tot = Convert.ToString(Convert.ToInt32(qty1) - Convert.ToInt32(q1));
                        Convert.ToInt32(tot);
                        cmd = new OleDbCommand("update stock_tbl set qty=" + tot + " where pro_type='" + textBox2.Text + "'", con);
                        cmd.ExecuteReader();
                        MessageBox.Show("stock updated...");




                        display();

                    }

                }

                con.Close();
          //  }
           
                    
        }*/
    }
}
