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
using System.Text.RegularExpressions;


namespace sanghprojects
{
    public partial class compony_master : Form
    {

        DataTable dt = new DataTable();
        int pos = 0;
    //    int index = 0;
       
        
        public compony_master()
        {
            InitializeComponent();
        }
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        int id;
      
        public void display()
        {
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from comp_mstr_tbl order by comp_nm asc";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void ShowData(int index)
        {

            textBox1.Text = dt.Rows[index][0].ToString();
            comboBox1.Text = dt.Rows[index][1].ToString();
            comboBox5.Text = dt.Rows[index][2].ToString();
           richTextBox1.Text = dt.Rows[index][3].ToString();
           textBox5.Text = dt.Rows[index][4].ToString();
            textBox4.Text = dt.Rows[index][5].ToString();
            textBox3.Text = dt.Rows[index][6].ToString();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
//first
        private void button7_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            button9.Enabled = true;
            pos--;
            if (pos >= 0)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("First the record");
            }


           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
          
        }

        private void compony_master_Load(object sender, EventArgs e)
        {

            OleDbConnection conn = new OleDbConnection(s);
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from comp_mstr_tbl", conn);
            adt.Fill(dt);

               label1.Text = System.DateTime.Now.ToString("d");
            label12.Text = System.DateTime.Now.ToString("t");
            OleDbConnection con1 = new OleDbConnection(s);
            OleDbDataAdapter dap = new OleDbDataAdapter("select * from comp_mstr_tbl orser by comp_id asc",con1);


            //radio id

            OleDbConnection con = new OleDbConnection(s);
            con.Open();

            
            string s3 = "select comp_id from comp_mstr_tbl order by comp_id asc";
            OleDbCommand cmd3 = new OleDbCommand(s3, con);

            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da2.Fill(ds3);

            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
            }


            //radio  name

            
            string s4 = "select distinct comp_nm from comp_mstr_tbl";
            OleDbCommand cmd4 = new OleDbCommand(s4, con);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text==""||comboBox1.SelectedItem == "" || comboBox5.SelectedItem == "" || richTextBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("please enter required field");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();


                    string s1 = "select * from comp_mstr_tbl where comp_id="+textBox1.Text+"";
                    OleDbCommand cmd1 = new OleDbCommand(s1,con);
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

                        string str = "insert into comp_mstr_tbl(comp_id,comp_nm,address,state,mobile,postalcode,email) values(" + textBox1.Text + ",'" + comboBox5.SelectedItem + "','" + richTextBox1.Text + "','" + comboBox1.SelectedItem + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                        OleDbCommand cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("insert success");
                        display();
                        reset();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please insert properly");
                
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
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
                else
                {
                    MessageBox.Show("must be select row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("must be select row");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            try
            {
                if (textBox1.Text == "" || comboBox1.Text== "" || comboBox5.Text== "" || richTextBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("select record in gridview");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();
                    string str = "update comp_mstr_tbl set comp_id=" + textBox1.Text + ",state='" + comboBox1.SelectedItem + "',comp_nm='" + comboBox5.SelectedItem + "',address='" + richTextBox1.Text + "',mobile='" + textBox5.Text + "',postalcode='" + textBox4.Text + "' ,email='" + textBox3.Text + "' where comp_id=" + id + " ";
                    OleDbCommand cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update success");
                    display();
                    con.Close();
                    reset();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("update properly"+ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox1.SelectedItem == "" || comboBox5.SelectedItem == "" || richTextBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("select record in gridview");
                }
                else
                {
                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("delete comp_id,state,comp_nm,address,mobile,postalcode,email from comp_mstr_tbl where comp_id=" + id + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete record success");
                    con.Close();
                    display();
                    reset();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please delete properly");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }
        public void reset()

        {
            try
            {

                comboBox1.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                richTextBox1.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("please proper delete");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            reset();
            
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
                comboBox3.Visible = true;
                comboBox4.Visible = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Visible = false;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from comp_mstr_tbl where comp_id=" + comboBox4.SelectedItem + "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
            reset();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
            comboBox3.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from comp_mstr_tbl where comp_nm='" + comboBox3.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            display();
        }
//next
        private void button8_Click(object sender, EventArgs e)
        {
            button9.Enabled = true;
            pos++;
            if (pos < dt.Rows.Count)
            {
                ShowData(pos);
            }
            else
            {
                MessageBox.Show("END of the record");
                pos = dt.Rows.Count - 1;
            }
        }
//previous
        private void button9_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = true;
            pos = dt.Rows.Count - 1;
            ShowData(pos);
        }
        //last
        private void button10_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button8.Enabled = true;
            pos = 0;
            ShowData(pos);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.SelectedItem == "Rajasthan")
                {
                    textBox4.Text = "RJ";
                }
                if (comboBox1.SelectedItem == "UP")
                {
                    textBox4.Text = "UP";
                }
                if (comboBox1.SelectedItem == "MP")
                {
                    textBox4.Text = "MP";

                }
                if (comboBox1.SelectedItem == "delhi")
                {
                    textBox4.Text = "DL";
                }
                if (comboBox1.SelectedItem == "Maharashtra")
                {
                    textBox4.Text = "MH";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please select proper data");
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox3.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                MessageBox.Show("Please! Enter Valid Email ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!Regex.Match(textBox5.Text, @"^\d{10}$").Success)
            {
                MessageBox.Show("Enter Only 10 Digit in Mobile No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
