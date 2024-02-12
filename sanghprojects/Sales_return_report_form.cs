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
    public partial class Sales_return_report_form : Form
    {
        public Sales_return_report_form()
        {
            InitializeComponent();
        }
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        int id;

        

        DataTable dt = new DataTable();
        int pos = 0;
     //   int index = 0;

        private void button6_Click(object sender, EventArgs e)
        {
            mdi M = new mdi();
            M.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select pro_id,pro_name,pro_type,Sales_date,qtn,unit_price,gst,Cust_nm from Sales_entry_tbls where Sales_bill_no=" + comboBox1.SelectedItem + "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();

            reader.Read();
            textBox1.Text = reader.GetValue(0).ToString();
            textBox3.Text = reader.GetValue(1).ToString();
            textBox7.Text = reader.GetValue(2).ToString();
            textBox8.Text = reader.GetValue(3).ToString();
            textBox9.Text = reader.GetValue(4).ToString();
            textBox10.Text = reader.GetValue(5).ToString();
            textBox12.Text = reader.GetValue(6).ToString();
            textBox6.Text = reader.GetValue(7).ToString();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void showdata(int index)
        {
            textBox2.Text = dt.Rows[index][0].ToString();
            comboBox1.Text = dt.Rows[index][1].ToString();
            textBox6.Text = dt.Rows[index][2].ToString();
            textBox1.Text = dt.Rows[index][3].ToString();
            textBox3.Text = dt.Rows[index][4].ToString();
            textBox7.Text = dt.Rows[index][5].ToString();
            textBox8.Text = dt.Rows[index][6].ToString();

            dateTimePicker1.CustomFormat = dt.Rows[index][7].ToString();
            textBox9.Text = dt.Rows[index][8].ToString();
            textBox5.Text = dt.Rows[index][9].ToString();
            textBox10.Text = dt.Rows[index][10].ToString();
            textBox11.Text = dt.Rows[index][11].ToString();
            textBox12.Text = dt.Rows[index][12].ToString();
            textBox13.Text = dt.Rows[index][13].ToString();




        }

      /*  public void showdata(int index)
        {
            textBox2.Text = dt.Rows[index][0].ToString();
            comboBox1.Text = dt.Rows[index][1].ToString();
            textBox6.Text = dt.Rows[index][2].ToString();
            textBox1.Text = dt.Rows[index][3].ToString();
            textBox3.Text = dt.Rows[index][4].ToString();
            textBox7.Text = dt.Rows[index][5].ToString();
            textBox8.Text = dt.Rows[index][6].ToString();

            dateTimePicker1.Text = dt.Rows[index][7].ToString();
            textBox9.Text = dt.Rows[index][8].ToString();
            textBox5.Text = dt.Rows[index][9].ToString();
            textBox10.Text = dt.Rows[index][10].ToString();
            textBox11.Text = dt.Rows[index][11].ToString();
            textBox12.Text = dt.Rows[index][12].ToString();
            textBox13.Text = dt.Rows[index][13].ToString();




        }*/


        private void Sales_return_report_form_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(s);
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from sale_ret_tbl", conn);
            adt.Fill(dt);
            
            label1.Text = System.DateTime.Now.ToString("d");
            label19.Text = System.DateTime.Now.ToString("t");

            comboBox3.Visible = false;
            comboBox4.Visible = false;

            OleDbConnection con = new OleDbConnection(s);
            string s2 = "select Sales_bill_no from Sales_entry_tbls";
            OleDbCommand cmd1 = new OleDbCommand(s2, con);

            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
            }

            //radiobutton id

            comboBox4.Visible = true;
            string s3 = "select sales_r_id from sale_ret_tbl order by sales_r_id asc";
            OleDbCommand cmd3 = new OleDbCommand(s3, con);

            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da2.Fill(ds3);

            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
            }



            //radio  name

           
            string s4 = "select distinct pro_name from sale_ret_tbl";
            OleDbCommand cmd4 = new OleDbCommand(s4, con);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }
        int p, rqty, gst, na, amt;
        int q1, q2;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox7.Text == "" || dateTimePicker1.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox5.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text=="")
            {
                MessageBox.Show("please required all field");
            }
            else
            {
               
                    OleDbConnection con = new OleDbConnection(s);
                 
                    con.Open();

                string s1 = "select * from sale_ret_tbl where sales_r_id="+textBox2.Text+"";
                    OleDbCommand cmd1 = new OleDbCommand(s1,con);
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("duplicate record not allow");
                    }
                    else
                    {

                        string str = "insert into sale_ret_tbl(sales_r_id,sales_bill_no,Cust_nm,pro_id,pro_name,pro_type,Sales_dt,Sales_r_dt,s_qtn,r_qtn,unit_price,total_price,r_gst,net_price) values(" + textBox2.Text + "," + comboBox1.SelectedItem + ",'" + textBox6.Text + "'," + textBox1.Text + ",'" + textBox3.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Text + "'," + textBox9.Text + "," + textBox5.Text + "," + textBox10.Text + "," + textBox11.Text + "," + textBox12.Text + "," + textBox13.Text + ")";
                        OleDbCommand cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();
                        OleDbDataReader dr;
                        MessageBox.Show("insert success");
                        cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox1.Text + "", con);
                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                q1 = Convert.ToInt32(dr[0]);
                            }
                        }

                        MessageBox.Show("qty is : " + q1);
                        q2 = q1 + (Convert.ToInt32(textBox5.Text));
                        MessageBox.Show("updated qty is : " + q2);

                        cmd = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_id=" + textBox1.Text + "", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("stock is updated..");
                        con.Close();
                        display();
                        reset();
                    }
                   // reset();
                }
                 
                
            
        }
        int p1, p2;
        int q3;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox10.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox9.Enabled = false;

            if (textBox2.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox7.Text == "" || dateTimePicker1.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox5.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("please select all record in gridview");
            }
            else
            {
                
              
           


                    OleDbConnection con = new OleDbConnection(s);
                    OleDbCommand cmd;
                    OleDbDataReader dr;
                    con.Open();

                    cmd = new OleDbCommand("select r_qtn from sale_ret_tbl where pro_id=" + textBox1.Text + "", con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            p1 = Convert.ToInt32(dr[0]);
                        }
                    }
                   


                    string str = "update sale_ret_tbl set sales_r_id=" + textBox2.Text + ",sales_bill_no=" + comboBox1.SelectedItem + ",Cust_nm='"+textBox6.Text+"',pro_id=" + textBox1.Text + ",pro_name='" + textBox3.Text + "',pro_type='" + textBox7.Text + "',Sales_dt='" + textBox8.Text + "',Sales_r_dt='" + dateTimePicker1.Text + "',s_qtn=" + textBox9.Text + ",r_qtn=" + textBox5.Text + ",unit_price=" + textBox10.Text + ",total_price=" + textBox11.Text + ",r_gst=" + textBox12.Text + ",net_price=" + textBox13.Text + " where sales_r_id=" + id + "";
                    cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update success");

                    if (textBox1.Text != null)
                    {
                        cmd = new OleDbCommand("select r_qtn from sale_ret_tbl where pro_id=" + textBox1.Text + "", con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                p2 = Convert.ToInt32(dr[0]);
                            }
                        }
                        cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox1.Text + "", con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                q3 = Convert.ToInt32(dr[0]);
                                //  q1 = Convert.ToInt32(dr[0]);
                            }
                        }
                    }
                    MessageBox.Show("total qty is : " + q3);
                    MessageBox.Show("old qty is : " + p1);
                    MessageBox.Show("new is : " + p2);
                    int d = q3;
                    q3 = d + p1;
                    q2 = d - (Convert.ToInt32(textBox9.Text));
                    MessageBox.Show("updated qty is : " + q2);

                    cmd = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_id=" + textBox1.Text + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("stock is updated..");
                    con.Close();

                    
                  
                    display();
                    reset();
               
            }
        }

        public void display()
        {

            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from sale_ret_tbl";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }
        public void reset()
        {


            textBox2.Text = "";
            comboBox1.Text="";
            textBox6.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            dateTimePicker1.Text = string.Empty;

            textBox5.Text="";
            textBox9.Text="";
            textBox10.Text="";
            textBox11.Text="";
            textBox12.Text="";
            textBox13.Text="";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.Text == "" || textBox6.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox7.Text == "" || dateTimePicker1.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox5.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("please select all record in gridview");
            }
            else
            {


                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "delete * from sale_ret_tbl where sales_r_id=" + id + "";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;


                OleDbDataReader dr;

                if (textBox1.Text != null)
                {
                    cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox1.Text + "", con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            q3 = Convert.ToInt32(dr[0]);
                        }
                    }
                }
                MessageBox.Show("qty is : " + q3);
                q2 = q3 + (Convert.ToInt32(textBox5.Text));
                MessageBox.Show("updated qty is : " + q2);

                cmd = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_id=" + textBox1.Text + "", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("stock is updated..");

                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox9.Enabled = false;
            textBox13.Enabled = false;



            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                   
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                   
                }

                else
                {
                    MessageBox.Show("must be select row");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("please select right row");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = true;
            comboBox4.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
            comboBox3.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            display();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from sale_ret_tbl where pro_name='" + comboBox3.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from sale_ret_tbl where sales_r_id=" + comboBox4.SelectedItem + " order by sales_r_id asc";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            button9.Enabled = true;
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

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = true;
            pos = dt.Rows.Count - 1;
            showdata(pos);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button8.Enabled = true;
            pos = 0;
            showdata(pos);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            double s_qtn = Convert.ToDouble(textBox9.Text);
            double r_qtn = Convert.ToDouble(textBox5.Text);

            if (r_qtn <= s_qtn)
            {
                double unit_price = Convert.ToDouble(textBox10.Text);
                double gst = Convert.ToDouble(textBox12.Text);
                double qtn = s_qtn + r_qtn;
                double total = qtn * unit_price;
                textBox11.Text = Convert.ToString(total);
                double n_qtn = s_qtn - r_qtn;
                double net_price;
                double r_net = n_qtn * unit_price;

                double r_gst = Convert.ToDouble(textBox12.Text);
                if (r_qtn == 0)
                {
                    textBox13.Text = Convert.ToString(total);
                }
                else
                {

                    if (s_qtn >= r_qtn)
                    {
                        net_price = total - (n_qtn * gst / 100);
                        textBox13.Text = Convert.ToString(net_price);
                    }
                    else
                    {
                        if (MessageBox.Show(" return quantity must be enter less ", "warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            textBox9.Text = "";
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show(" return quantity must be enter less ", "warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox5.Text = "";
                }

            }
          
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
    }
}
