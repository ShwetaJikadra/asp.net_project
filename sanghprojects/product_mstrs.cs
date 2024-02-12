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
    public partial class product_mstrs : Form
    {
        DataTable dt = new DataTable();
        int pos = 0;
      //  int index = 0;
        public product_mstrs()
        {
            InitializeComponent();
        }
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        int id;
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void product_mstrs_Load(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            comboBox4.Visible = false;
            radioButton1.Checked = false; ;
            radioButton2.Checked = false;
            radioButton3.Checked =true;


            OleDbConnection conn = new OleDbConnection(s);
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from product_mstr_tbl", conn);
            adt.Fill(dt);



            //customer id
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string s1 = "select pro_id from product_mstr_tbl";
            OleDbCommand cmd = new OleDbCommand(s1, con);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

           /* for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox7.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }*/
            label1.Text = System.DateTime.Now.ToString("d");
            label11.Text = System.DateTime.Now.ToString("t");

            comboBox6.Items.Add("a");
            display();

          //radiobutton id
           
                comboBox4.Visible = true;
                string s3 = "select pro_id from product_mstr_tbl order by pro_id asc";
                OleDbCommand cmd3 = new OleDbCommand(s3, con);

                OleDbDataAdapter da2 = new OleDbDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                da2.Fill(ds3);

                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    comboBox4.Items.Add(ds3.Tables[0].Rows[i][0].ToString());
                }


            //radio  name

                comboBox2.Visible = true;
                string s4 = "select distinct pro_name from product_mstr_tbl";
                OleDbCommand cmd4 = new OleDbCommand(s4, con);

                OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4);

                for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                {
                    comboBox2.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
                }
            


        }

       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            mdi m = new mdi();
            m.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
          

                if (comboBox1.Text== "" || comboBox5.Text == "" || textBox2.Text == "" || comboBox6.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("please enter required field");
                }
                else
                {


                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();

                    string s1 = "select * from product_mstr_tbl where pro_id="+textBox1.Text+"";
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

                        string str = "insert into product_mstr_tbl(pro_id,pro_name,pro_type,tax_rate,comp_nm,unit_price) values(" + textBox1.Text + ",'" + comboBox1.SelectedItem + "','" + comboBox5.SelectedItem + "','" + textBox2.Text + "','" + comboBox6.SelectedItem + "','" + textBox3.Text + "')";
                        OleDbCommand cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();
                        string qry = "insert into stock_tbl values(" + textBox1.Text + ",'" + comboBox1.SelectedItem + "','" + comboBox5.SelectedItem + "',0)";
                        cmd = new OleDbCommand(qry, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("insert successfully....");

                        con.Close();
                        MessageBox.Show("insert success");
                        display();
                        reset();
                    }
                }
           
        }
        public void reset()
        {
            try
            {
                textBox1.Clear();
                comboBox1.Text="";
                comboBox5.Text = "";
                textBox2.Text = "";
                comboBox6.Text="";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("reset success" + ex.ToString());
            }



        }
        public void display()
        {
            try
            {

                OleDbConnection con = new OleDbConnection(s);
                con.Open();
                string dis = "select * from product_mstr_tbl order by pro_id asc";
                OleDbCommand cmd = new OleDbCommand(dis, con);
                var reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                con.Close();
                reset();
            }
            catch (Exception)
            {
                MessageBox.Show("please select proper");
              
            }
        }

        public void a()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled=true;
            button6.Enabled = true;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled =true;
            button2.Enabled = true;
            button3.Enabled = true;


            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    comboBox5.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                   
                }
                else if (e.RowIndex <= 0)
                {

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
                else
                {
                    MessageBox.Show("must be select row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("select  proper row");
                

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button4.Enabled = true;
            button6.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
            button5.Enabled = true;
           


                if (textBox1.Text == "" || comboBox1.Text== "" || comboBox5.Text== "" || textBox2.Text == "" || comboBox6.Text== "" || textBox3.Text == "")
                {
                    MessageBox.Show("please select record in gridview");
                }
                else
                {
                    comboBox5.SelectedItem = -1;

                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();

                    string str = "update product_mstr_tbl set pro_id=" + textBox1.Text + ", pro_name='" + comboBox1.SelectedItem + "',pro_type='" + comboBox5.SelectedItem + "',tax_rate='" + textBox2.Text + "',comp_nm='" + comboBox6.SelectedItem + "',unit_price='" + textBox3.Text + "' where pro_id=" + id + " ";
                    OleDbCommand cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Are you want to Edit record ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    display();
                    reset();
                    con.Close();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;


                }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
             // 3465
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
           


                OleDbConnection con = new OleDbConnection(s);
                OleDbCommand cmd;
                con.Open();
                 cmd = new OleDbCommand("delete pro_id,pro_name,pro_type,tax_rate,comp_nm,unit_price from product_mstr_tbl where pro_id=" + id + "", con);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("delete from stock_tbl where pro_id="+id+"",con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Record SuccessFully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                con.Close();
                display();
                a();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
            a();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

           
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            
            if (radioButton3.Checked)
            {
                comboBox4.Visible = true;
                comboBox2.Visible = false;

             
            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            comboBox4.Visible = false;
            comboBox2.Visible = false;
            display();
            reset();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from product_mstr_tbl where pro_id="+comboBox4.SelectedItem+" order by pro_id asc";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
            a();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            display();
            reset();
            a();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

          
            if (radioButton2.Checked == true)
            {
                comboBox2.Visible = true;
                comboBox4.Visible = false;


               
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Visible = false;
            comboBox2.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from product_mstr_tbl where pro_name='" + comboBox2.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public void showdata(int index)
        {
            textBox1.Text = dt.Rows[index][0].ToString();
           comboBox1.Text= dt.Rows[index][1].ToString();
            comboBox5.Text = dt.Rows[index][2].ToString();
            textBox2.Text = dt.Rows[index][3].ToString();
            comboBox6.Text = dt.Rows[index][4].ToString();
            textBox3.Text = dt.Rows[index][5].ToString();
          
        }

//last
        private void button9_Click(object sender, EventArgs e)
        {
          
            pos = dt.Rows.Count - 1;
            showdata(pos);
        }
//pre
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
//first
        private void button10_Click(object sender, EventArgs e)
        {
           
          
            pos = 0;
            showdata(pos);
            
        }
//next
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textbox1_validating(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == "Furtilizers")
            {
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox5.Items.Add("Urea");
                comboBox5.Items.Add("Urea Phosphate");
                comboBox5.Items.Add("Phosphate");
                comboBox5.Items.Add("Nitrogen");
                comboBox6.Items.Add("Riffco");
                comboBox6.Items.Add("Iffco");
                comboBox6.Items.Add("Nirma");
                comboBox6.Items.Add("Narmada");
            }
            if (comboBox1.SelectedItem == "Crackers")
            {
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox5.Items.Add("Bomb of Mirchi");
                comboBox5.Items.Add("flowers bomb");
                comboBox5.Items.Add("Jyoti Bomb");
                comboBox5.Items.Add("Deep Crackers");
                comboBox5.Items.Add("Pomegranate");
                comboBox6.Items.Add("sony firework");
                comboBox6.Items.Add("v2 Standard");

            }

            if (comboBox1.SelectedItem == "Books")
            {
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox5.Items.Add("Diary Book");
                comboBox5.Items.Add("white page Book");
                comboBox5.Items.Add("Notes");
                comboBox5.Items.Add("College Books");
                comboBox5.Items.Add("Raw Page Books");
                comboBox6.Items.Add("Navneet");
                comboBox6.Items.Add("Gujrat Sarkar");

            }

            if (comboBox1.SelectedItem == "Beeds")
            {
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox5.Items.Add("kapas beeds");
                comboBox5.Items.Add("vegetables Beeds");
                comboBox5.Items.Add(" cereal Beeds");
                comboBox5.Items.Add("sunFlowers Beeds");
                comboBox6.Items.Add("Gujjco");
                comboBox6.Items.Add("Iffco");


            }

            if (comboBox1.SelectedItem == "Pesticide")
            {
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();
                comboBox5.Items.Add("flowers pasticide");
                comboBox5.Items.Add("cereals Pasticide");
                comboBox5.Items.Add("vegetable paticide");
                comboBox5.Items.Add("vegetable pasticide");
                comboBox6.Items.Add("Gujjco");
                comboBox6.Items.Add("Marshal");

            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
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

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only charcters...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                MessageBox.Show("Please! Enter only digits.....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

    }
}
