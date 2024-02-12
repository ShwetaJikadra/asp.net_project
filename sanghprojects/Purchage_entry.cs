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
    public partial class Purchage_entry : Form
    {

        DataTable dt = new DataTable();
        int pos = 0;
       // int index = 0;

        public Purchage_entry()
        {
            InitializeComponent();
        }

        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        OleDbConnection con = new OleDbConnection();
        int id;

        public void display()
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_entry_tbl";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            
        }

        public void showdata(int index)
        {
            try
            {
                textBox7.Text = dt.Rows[index][0].ToString();
                comboBox1.Text = dt.Rows[index][1].ToString();
                textBox5.Text = dt.Rows[index][2].ToString();
                textBox6.Text = dt.Rows[index][3].ToString();
                textBox2.Text = dt.Rows[index][4].ToString();
                textBox3.Text = dt.Rows[index][5].ToString();
                textBox4.Text = dt.Rows[index][6].ToString();
                textBox9.Text = dt.Rows[index][7].ToString();
                textBox1.Text = dt.Rows[index][8].ToString();
                textBox8.Text = dt.Rows[index][9].ToString();
                dateTimePicker1.Text = dt.Rows[index][10].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("ok");
            }


        }

        private void Purchage_entry_Load(object sender, EventArgs e)
        {
          /*  textBox7.Focus();
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            textBox1.Enabled = false;
         //   textBox8.Enabled = false;
          //  textBox6.Enabled = false;*/
            OleDbConnection conn = new OleDbConnection(s);
           
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from pur_entry_tbl", conn);
            adt.Fill(dt);
            
            radioButton3.Checked = true;
            comboBox4.Visible = true;
            comboBox3.Visible = false;
            
            label1.Text = System.DateTime.Now.ToString("d");
            label12.Text = System.DateTime.Now.ToString("t");

          
          
  //pro_id 
            OleDbConnection con = new OleDbConnection(s);
            string s2 = "select pro_id from product_mstr_tbl";
            OleDbCommand cmd1 = new OleDbCommand(s2, con);

            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
            }


          


            //radio id

          
            con.Open();

            comboBox4.Visible = true;
            string s4 = "select distinct pur_bill_no from pur_entry_tbl";
            OleDbCommand cmd4 = new OleDbCommand(s4, con);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }

            //radio  name

            comboBox3.Visible = true;
            string s5 = "select distinct pro_name from pur_entry_tbl";
            OleDbCommand cmd5 = new OleDbCommand(s5, con);

            OleDbDataAdapter da5 = new OleDbDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            da5.Fill(ds5);

            for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds5.Tables[0].Rows[i][0].ToString());
            }

           
           
        }

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        string q1, qty1, tot;
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (textBox7.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""   || textBox9.Text == "" ||textBox1.Text==""|| textBox8.Text == ""||dateTimePicker1.Text=="")
            {
                MessageBox.Show("please enter required field");
            }
            else
            {
                OleDbConnection con = new OleDbConnection(s);
                OleDbDataReader dr;
                con.Open();

                 string s1 = "select * from pur_entry_tbl where pur_bill_no="+textBox7.Text+"";
                    OleDbCommand cmd1 = new OleDbCommand(s1,con);
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("duplicate record not allow");
                        textBox7.Focus();
                    }
                    else
                    {
                        q1 = textBox2.Text;
                        string str = "insert into pur_entry_tbl(pur_bill_no,pro_id,pro_name,pro_type,qtn,unit_price,total_price,Comp_nm,gst,net_price,pur_dt) values(" + textBox7.Text + ",'" + comboBox1.SelectedItem + "','" + textBox5.Text + "','" + textBox6.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox9.Text + "'," + textBox1.Text + "," + textBox8.Text + ",'" + dateTimePicker1.Text + "')";

                        OleDbCommand cmd = new OleDbCommand(str, con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("insert success");

                        cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox6.Text + "'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            qty1 = dr[0].ToString();
                        }
                        tot = Convert.ToString(Convert.ToInt32(qty1) + Convert.ToInt32(q1));
                        Convert.ToInt32(tot);
                        cmd = new OleDbCommand("update stock_tbl set qty=" + tot + " where pro_type='" + textBox6.Text + "'", con);
                        cmd.ExecuteReader();
                        MessageBox.Show("stock updated...");

                        con.Close();

                        display();
                        reset();
                        textBox7.Focus();
                    }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Convert.ToString(textBox1.Text);
            Convert.ToString(textBox2.Text);
            Convert.ToString(textBox3.Text);
            Convert.ToString(textBox8.Text);
            Convert.ToString(textBox4.Text);
            Convert.ToString(textBox3.Text);
            Convert.ToString(textBox1.Text);
            Convert.ToString(textBox8.Text);
            Convert.ToString(textBox5.Text);




           
                if (e.RowIndex >= 0)
                {

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                    textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                  //  dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    
                }
                else
                {
                    MessageBox.Show("must be select row");
                }
           
        }
        int oq = 0, nq = 0;
        private void button2_Click(object sender, EventArgs e)
        {
           
            if (textBox7.Text == "" || comboBox1.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""|| textBox9.Text == "" || textBox1.Text == "" || textBox8.Text == "" || dateTimePicker1.Text=="")
            {
                MessageBox.Show("please select record in gridview");
            }
            else
            {
                OleDbConnection con = new OleDbConnection(s);
                OleDbCommand cmd1;
                OleDbDataReader dr;
                con.Open();

                int s_q = 0, q2;
               

                cmd1 = new OleDbCommand("select qtn from pur_entry_tbl where pro_type='" + textBox6.Text + "'", con);
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    oq = Convert.ToInt32(dr[0]);
                }

                string str = "update pur_entry_tbl set pro_id='" + comboBox1.SelectedItem + "',pro_name='" + textBox5.Text+ "',pro_type='"+textBox6.Text+"',qtn=" + textBox2.Text + ",unit_price='" + textBox3.Text + "' ,total_price=" + textBox4.Text + ",Comp_nm='"+textBox9.Text+"',gst="+textBox1.Text+",net_price="+textBox8.Text+" where pur_bill_no=" + id + " ";
                OleDbCommand cmd = new OleDbCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("update success");

                cmd1 = new OleDbCommand("select qtn from pur_entry_tbl where pro_type='" + textBox6.Text + "'", con);
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    nq = Convert.ToInt32(dr[0]);
                }
                cmd1 = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox6.Text+ "'", con);
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    s_q = Convert.ToInt32(dr[0]);
                }
                MessageBox.Show("total qty is : " + s_q);
                MessageBox.Show("old qty is : " + oq);
                MessageBox.Show("new is : " + nq);
                s_q = s_q - oq;
                q2 = s_q + (Convert.ToInt32(textBox2.Text));
                MessageBox.Show("updated qty is : " + q2);
                cmd1 = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_type='" +textBox6.Text+ "'", con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("stock updated....");
                con.Close();
                display();
                reset();
               
                textBox7.Focus();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          /*  OleDbConnection con = new OleDbConnection(s);
            con.Open();
            OleDbCommand cmd = new OleDbCommand("delete pro_id,pro_name,pro_type,bill_no,qtn,unit_price,total_price,gst,net_price from pur_entry_tbl where pur_bill_no=" + id + "", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("delete record success");
            con.Close();
            display();*/
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void reset()
        {
          /*  Convert.ToString(textBox1.Text);
            Convert.ToString(textBox2.Text);
            Convert.ToString(textBox3.Text);
            Convert.ToString(textBox8.Text);*/
                 
           
                textBox7.Text="";
                comboBox1.Text = " ";
                textBox5.Text="";
                textBox6.Text="";
                textBox2.Text="";


                textBox3.Text = "";

                textBox4.Text = "";

                textBox9.Text="";
                textBox1.Text="";
                textBox8.Text="";
           

        }
        private void button5_Click(object sender, EventArgs e)
        {

           /* Convert.ToString(textBox1.Text);
            Convert.ToString(textBox2.Text);
            Convert.ToString(textBox3.Text);
            Convert.ToString(textBox8.Text);*/

            reset();
            textBox1.Focus();
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox3.Visible = true;
                comboBox4.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox4.Visible = true;
                comboBox3.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            display();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
            comboBox3.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_entry_tbl where pro_name='" + comboBox3.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_entry_tbl where pur_bill_no=" + comboBox4.SelectedItem+ "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "select pro_name,pro_type,unit_price,comp_nm from product_mstr_tbl where pro_id=" + comboBox1.SelectedItem + "";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();
               
                reader.Read();
                textBox5.Text = reader.GetValue(0).ToString();
                textBox6.Text = reader.GetValue(1).ToString();
                textBox3.Text = reader.GetValue(2).ToString();
                textBox9.Text = reader.GetValue(3).ToString();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "Furtilizers")
            {
                textBox1.Text = "22";
            }
            if (textBox5.Text == "Beeds")
            {
                textBox1.Text = "18";
            }
            if (textBox5.Text == "Books")
            {
                textBox1.Text = "0";
            }
            if (textBox5.Text == "Pesticide")
            {
                textBox1.Text = "18";
            }
            if (textBox5.Text == "Crackers")
            {
                textBox1.Text = "0";
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
           
                if (textBox7.Text == "" || comboBox1.Text== "" || textBox5.Text == "" || textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "" || textBox8.Text == "" || dateTimePicker1.Text == "")
                {
                    MessageBox.Show("please select record in gridview");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    OleDbDataReader dr;
                    con.Open();
                    string str1 = "delete pur_bill_no,pro_id,pro_name,pro_type,qtn,unit_price,total_price,gst,net_price from pur_entry_tbl where pur_bill_no=" + id + "";
                    OleDbCommand cmd = new OleDbCommand(str1, con);
                    cmd.ExecuteNonQuery();
                 
                    MessageBox.Show("Delete Record SuccessFully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    q1 = textBox2.Text;

                    cmd = new OleDbCommand("select qty from stock_tbl where pro_type='" + textBox6.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        qty1 = dr[0].ToString();
                    }
                    tot = Convert.ToString(Convert.ToInt32(qty1) - Convert.ToInt32(q1));
                    cmd = new OleDbCommand("update stock_tbl set qty='" + tot + "' where pro_type='" + textBox6.Text + "'", con);
                    cmd.ExecuteReader();
                    MessageBox.Show("stock updated...");

                    con.Close();
                    display();
                }
            
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
           




            display();
           
            textBox7.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           

               

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(textBox3.Text);
                double t = a * b;
                textBox4.Text = Convert.ToString(t);
                Convert.ToString(textBox4.Text);
                Convert.ToString(textBox3.Text);
                Convert.ToString(textBox1.Text);
                Convert.ToString(textBox8.Text);
                Convert.ToString(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("please perform sequentially");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            try
            {
                double gst = Convert.ToDouble(textBox1.Text);
                double tot = Convert.ToDouble(textBox4.Text);
                double net = (tot * (gst / 100) + tot);
                textBox8.Text = Convert.ToString(net);
                Convert.ToString(textBox4.Text);
                Convert.ToString(textBox1.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("ok");
            }
          
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

          
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "select pro_name,pro_type,unit_price,comp_nm from product_mstr_tbl where pro_id=" + comboBox1.SelectedItem + "";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();

                reader.Read();
                textBox5.Text = reader.GetValue(0).ToString();
                textBox6.Text = reader.GetValue(1).ToString();
                textBox3.Text = reader.GetValue(2).ToString();
                textBox9.Text = reader.GetValue(3).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }
    }
}
