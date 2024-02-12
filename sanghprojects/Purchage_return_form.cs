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
    public partial class Purchage_return_form : Form
    {

        DataTable dt = new DataTable();
        int pos = 0;
      //  int index = 0;

        public Purchage_return_form()
        {
            InitializeComponent();
        }
        string s = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\group-2\database_pro\db.mdb";
        int id;
      //  OleDbDataReader dr;

        private void Purchage_return_form_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(s);
           
            OleDbDataAdapter adt = new OleDbDataAdapter("select * from pur_ret_tbl", conn);
            adt.Fill(dt);

            
            OleDbConnection con = new OleDbConnection(s);
            string s2 = "select pur_bill_no from pur_entry_tbl";
            OleDbCommand cmd1 = new OleDbCommand(s2, con);

            OleDbDataAdapter da1 = new OleDbDataAdapter(cmd1);
        
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
            }

            //radiobutton id

            comboBox4.Visible = true;
            string s3 = "select pur_r_id from pur_ret_tbl order by pur_r_id asc";
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
            string s4 = "select distinct pro_name from pur_ret_tbl";
            OleDbCommand cmd4 = new OleDbCommand(s4, con);

            OleDbDataAdapter da4 = new OleDbDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4);

            for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(ds4.Tables[0].Rows[i][0].ToString());
            }
            
        }

        public void showdata(int index)
        {
            textBox1.Text = dt.Rows[index][0].ToString();
            comboBox2.Text = dt.Rows[index][1].ToString();
            textBox3.Text = dt.Rows[index][2].ToString();
            textBox2.Text = dt.Rows[index][3].ToString();
            textBox6.Text = dt.Rows[index][4].ToString();
            textBox5.Text = dt.Rows[index][5].ToString();
           

            dateTimePicker2.CustomFormat = dt.Rows[index][6].ToString();
            textBox4.Text = dt.Rows[index][7].ToString();
            textBox8.Text = dt.Rows[index][8].ToString();
            textBox9.Text = dt.Rows[index][9].ToString();
            textBox12.Text = dt.Rows[index][10].ToString();
            textBox7.Text = dt.Rows[index][11].ToString();
            textBox11.Text = dt.Rows[index][13].ToString();




        }

        string qty1, q1,tot;
        private void button1_Click(object sender, EventArgs e)
        {


            q1 = textBox8.Text;
            if (textBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox6.Text == "" || textBox5.Text == "" || dateTimePicker2.Text == "" || textBox4.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox7.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("please required all field");
            }
            else
            {
                
                    OleDbConnection con = new OleDbConnection(s);
                    OleDbDataReader dr;
                    con.Open();

                 string s1 = "select * from pur_ret_tbl where pur_r_id="+textBox1.Text+"";
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
                        string str = "insert into pur_ret_tbl(pur_r_id,pur_bill_no,pro_id,pro_name,pro_type,pur_dt,ret_dt,p_qtn,r_qtn,unit_price,total_price,comp_nm,r_gst,r_net_price) values(" + textBox1.Text + "," + comboBox2.SelectedItem + ",'" + textBox3.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + dateTimePicker2.Text + "'," + textBox4.Text + "," + textBox8.Text + ",'" + textBox9.Text + "'," + textBox10.Text + ",'" + textBox12.Text + "'," + textBox7.Text + "," + textBox11.Text + ")";
                        OleDbCommand cmd = new OleDbCommand(str, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("insert success");


                        cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox3.Text + "", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            qty1 = dr[0].ToString();

                        }
                        tot = Convert.ToString(Convert.ToInt32(qty1) - Convert.ToInt32(q1));
                        Convert.ToInt32(tot);
                        cmd = new OleDbCommand("update stock_tbl set qty=" + tot + " where pro_type='" + textBox6.Text + "'", con);
                        cmd.ExecuteReader();
                        MessageBox.Show("stock updated...");
                        con.Close();

                        display();
                        reset();
                    }
            }

        }


        public void display()
        {

            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_ret_tbl";
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
            reset();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= 1)
            {
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox6.Enabled = false;
                textBox5.Enabled = false;
                textBox4.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = true;
                textBox11.Enabled = false;
            }
            textBox7.Enabled = false;

            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                }

                else
                {
                    MessageBox.Show("must be select row");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("not any rows now");
            }

            
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select pro_id,pro_name,pro_type,pur_dt,qtn,unit_price,Comp_nm,gst from pur_entry_tbl where pur_bill_no=" + comboBox2.SelectedItem + "";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();

            reader.Read();
            textBox3.Text = reader.GetValue(0).ToString();
            textBox2.Text = reader.GetValue(1).ToString();
            textBox6.Text = reader.GetValue(2).ToString();
            textBox5.Text = reader.GetValue(3).ToString();
            textBox4.Text = reader.GetValue(4).ToString();
            textBox9.Text = reader.GetValue(5).ToString();
            textBox12.Text = reader.GetValue(6).ToString();
            textBox7.Text = reader.GetValue(7).ToString();
            // textBox4.Text = reader.GetValue(8).ToString();


        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {


        }
        int p1,p2;
        int q3, q2;
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox7.Enabled = false;
            if (textBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox6.Text == "" || textBox5.Text == "" || dateTimePicker2.Text == "" || textBox4.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox7.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("please required all field");
            }
            else
            {

                    OleDbConnection con = new OleDbConnection(s);
                    OleDbCommand cmd;
                    OleDbDataReader dr;
                    
                    con.Open();
                    cmd = new OleDbCommand("select r_qtn from pur_ret_tbl where pro_id='" + textBox3.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            p1 = Convert.ToInt32(dr[0]);
                        }
                    }
                   
                    string str = "update pur_ret_tbl set pur_r_id=" + textBox1.Text + ",pur_bill_no=" + comboBox2.SelectedItem + ",pro_id='" + textBox3.Text + "',pro_name='" + textBox2.Text + "',pro_type='" + textBox6.Text + "',pur_dt='" + textBox5.Text + "',ret_dt='" + dateTimePicker2.Text + "',p_qtn=" + textBox4.Text + ",r_qtn=" + textBox8.Text + ",unit_price=" + textBox9.Text + ",total_price=" + textBox10.Text + ",comp_nm='" + textBox12.Text + "',r_gst=" + textBox7.Text + ",r_net_price=" + textBox11.Text + " where pur_r_id=" + id + "";
                   cmd = new OleDbCommand(str, con);
                    cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("update success");


                    if (textBox3.Text != null)
                    {
                        cmd = new OleDbCommand("select r_qtn from pur_ret_tbl where pro_id='" + textBox3.Text + "'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                p2 = Convert.ToInt32(dr[0]);
                            }
                        }
                        cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox3.Text + "", con);
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
                    q3 = d - p1;
                    q2 = d + (Convert.ToInt32(textBox8.Text));
                    MessageBox.Show("updated qty is : " + q2);

                    cmd = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_id=" + textBox3.Text + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("stock is updated..");
                    con.Close();
                    display();
                      reset();
               
            }
        }
        public void reset()
        {
            textBox1.Clear();
            comboBox2.Text= "";
            textBox3.Clear();
            textBox2.Clear();
            textBox6.Clear();
            textBox5.Clear();
            dateTimePicker2.Text = string.Empty;
            textBox4.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox12.Clear();
            textBox7.Clear();
            textBox11.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Want To Exit...", "Exit..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox7.Enabled = false;


            if (textBox1.Text == "" || comboBox2.SelectedItem == "" || textBox3.Text == "" || textBox2.Text == "" || textBox6.Text == "" || textBox5.Text == "" || dateTimePicker2.Text == "" || textBox4.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox12.Text == "" || textBox7.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("please required all field");
            }
            else
            {
               

                    OleDbConnection con = new OleDbConnection(s);
                    con.Open();
                    string dis = "delete * from pur_ret_tbl where pur_r_id="+id+"";
                    OleDbCommand cmd = new OleDbCommand(dis, con);
                    var reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    OleDbDataReader dr;

                    if (textBox3.Text != null)
                    {
                        cmd = new OleDbCommand("select qty from stock_tbl where pro_id=" + textBox3.Text + "", con);
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
                    q2 = q3 - (Convert.ToInt32(textBox8.Text));
                    MessageBox.Show("updated qty is : " + q2);

                    cmd = new OleDbCommand("update stock_tbl set qty=" + q2 + " where pro_id=" + textBox3.Text + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("stock is updated..");
                    display();
                    con.Close();
                    
               
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
            comboBox2.Visible = false;
            comboBox4.Visible = false;
            display();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  comboBox4.Visible = false;
          //  comboBox2.Visible = true;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_ret_tbl where pro_name='" + comboBox3.SelectedItem + "'";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  comboBox2.Visible = false;
            OleDbConnection con = new OleDbConnection(s);
            con.Open();
            string dis = "select * from pur_ret_tbl where pur_r_id=" + comboBox4.SelectedItem + " order by pur_r_id asc";
            OleDbCommand cmd = new OleDbCommand(dis, con);
            var reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void textBox8_Leave(object sender, EventArgs e)
        {

            int pur_qtn = Convert.ToInt32(textBox4.Text);
            int ret_qtn = Convert.ToInt32(textBox8.Text);

            if (ret_qtn <= pur_qtn)
            {

                int unit_price = Convert.ToInt32(textBox9.Text);
                int a = pur_qtn - ret_qtn;
                int total = a * unit_price;
                textBox10.Text = Convert.ToString(total);
                int gst = Convert.ToInt32(textBox7.Text);



                if (gst == 0)
                {
                    textBox11.Text = textBox10.Text;
                }
                else
                {
                    int rt = ret_qtn * unit_price;
                    int rgst = ((rt * gst / 100));
                    int rg = rt + rgst;

                    textBox11.Text = Convert.ToString(rg);
                }
            }
            else
            {
                if (MessageBox.Show(" return quantity must be enter less ", "warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    textBox8.Text = "";
                }

            }

           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            double a1 = Convert.ToDouble(textBox9.Text.ToString());
            double a2 = Convert.ToDouble(textBox5.Text.ToString());

            if (a2 > a1)
            {
                MessageBox.Show("reteun qty must be less than sales");
                textBox5.Clear();
            }



            double s_qtn = Convert.ToDouble(textBox9.Text);
            double r_qtn = Convert.ToDouble(textBox5.Text);
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
                textBox10.Text = Convert.ToString(total);
            }
            else
            {
                net_price = total - (n_qtn * gst / 100);
                textBox10.Text = Convert.ToString(net_price);
            }
            /*   Convert.ToString(textBox9.Text);
               Convert.ToString(textBox5.Text);
               Convert.ToString(textBox10.Text);
               Convert.ToString(textBox12.Text);*/
            
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
