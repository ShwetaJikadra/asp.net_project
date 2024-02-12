using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace sanghprojects
{
    public partial class cust_master : Form
    {
        DataTable dt = new DataTable();
        int pos = 0;
      //  int index = 0;

        public cust_master()
        {
            InitializeComponent();
        }
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        int id;

        public void display()
        {

            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from cust_mstr_tbl";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
       
        private void button6_Click(object sender, EventArgs e)
        {
            mdi m1 = new mdi();
            m1.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox5.Text == "" || richTextBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("please enter required field");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();


                    string s1 = "select * from cust_mstr_tbl where Cust_id=" + textBox1.Text + "";
                    OleDbCommand cmd1 = new OleDbCommand(s1, con);
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("duplicate record not allow");
                        textBox1.Focus();
                    }
                    else
                    {
                        string str = "insert into cust_mstr_tbl(Cust_id,Cust_nm,Address,city,phone_no,pin_code,email) values(" + textBox1.Text + ",'" + textBox5.Text + "','" + richTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox7.Text + "','" + textBox4.Text + "')";
                        OleDbCommand cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("insert success");
                        display();
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select proper record"+ex.ToString());
            }
        }

        public void showdata(int index)
        {
            textBox1.Text = dt.Rows[index][0].ToString();
            textBox5.Text = dt.Rows[index][1].ToString();
            richTextBox1.Text = dt.Rows[index][2].ToString();
            textBox2.Text = dt.Rows[index][3].ToString();
            textBox3.Text = dt.Rows[index][4].ToString();
            textBox7.Text = dt.Rows[index][5].ToString();

            textBox4.Text = dt.Rows[index][6].ToString();

        }


        private void cust_master_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(s);
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from cust_mstr_tbl", conn);
            adt.Fill(dt);
            
            label1.Text = System.DateTime.Now.ToString("d");
            label12.Text = System.DateTime.Now.ToString("t");

            //radio id

            OleDbConnection con = new OleDbConnection(s);
            con.Open();

            comboBox4.Visible = true;
            string s3 = "select Cust_id from cust_mstr_tbl";
            OleDbCommand cmd3 = new OleDbCommand(s3, con);

            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da2.Fill(ds3);

            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
            }


            //radio  name

            comboBox3.Visible = true;
            string s4 = "select Cust_nm from cust_mstr_tbl order by Cust_id asc";
            OleDbCommand cmd4 = new OleDbCommand(s4, con);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }
            
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
                else
                {
                    MessageBox.Show("please select proper record");
                }
            }
            catch(Exception ex)

            {
             MessageBox.Show("please select properly record"+ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||textBox5.Text=="" || richTextBox1.Text== "" || textBox2.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox4.Text=="")
            {
                MessageBox.Show("select record in gridview");
            }
            else
            {
                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string str = "update cust_mstr_tbl set Cust_id="+textBox1.Text+",Cust_nm='" + textBox5.Text + "',Address='" + richTextBox1.Text + "',city='" + textBox2.Text + "',phone_no='" + textBox3.Text + "',pin_code='" + textBox7.Text + "',email='" + textBox4.Text + "' where Cust_id=" + id + " ";
                OleDbCommand cmd = new OleDbCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("update success");
                display();
                con.Close();
                reset();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox5.Text == "" || richTextBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("please select record in gridview");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("delete Cust_id,state,Cust_nm,Address,city,phone_no,pin_code,email from cust_mstr_tbl where Cust_id=" + id + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete record success");
                    con.Close();
                    display();
                    reset();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("please delete preper"+ex.ToString());
              
            }
        }
        public void reset()
        {
            try
            {

                textBox1.Clear();
                textBox5.Clear();
                richTextBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox7.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("reset success"+ex.ToString());
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox4.Visible = true;
                comboBox3.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox4.Visible = false;
                comboBox3.Visible = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            comboBox4.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from cust_mstr_tbl where Cust_id=" + comboBox4.SelectedItem + "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
            comboBox3.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from cust_mstr_tbl where Cust_nm='" + comboBox3.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            display();
        }

        private void button7_Click_1(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button8.Enabled = true;
            pos = 0;
            showdata(pos);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = true;
            pos = dt.Rows.Count - 1;
            showdata(pos);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox4.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                MessageBox.Show("Please! Enter Valid Email ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox7.Text, @"^\d{6}$").Success)
            {
                MessageBox.Show("Enter Only 6 Digit in Pincode No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox3.Text, @"^\d{10}$").Success)
            {
                MessageBox.Show("Enter Only 10 Digit in Mobile No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
            }
        }
    }
}
