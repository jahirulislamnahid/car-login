using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace Car
{
    public partial class Crud : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Crud()
        {
            InitializeComponent();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void button13_Click_1(object sender, EventArgs e)
        {
            BindGridView();
        }



        public void BindGridView()
            {


                SqlConnection con = new SqlConnection(cs);
                string query = "select * from REG";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;


                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
                dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                dataGridView1.RowTemplate.Height = 100;
            }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a1 = new Form1();
            a1.ShowDialog();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && pictureBox2.Image != null)
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "insert into REG values(@nid,@fname,@lname,@phone,@user,@pass,@img,@Time,@Date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@user", textBox5.Text);
                cmd.Parameters.AddWithValue("@pass", textBox6.Text);
                cmd.Parameters.AddWithValue("@img", SavePhoto());
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data Inserted Successfully ! ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Data not Inserted ! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Reset()
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                pictureBox2.Image = null;
            }

            byte[] SavePhoto()
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                return ms.GetBuffer();
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "update  REG set nid=@nid,FIRST_NAME=@fname,LAST_NAME=@lname,PHONE=@phone,USERNAME=@user,PASS=@pass,PIC=@img,Time=@Time,Date=@Date where nid=@nid";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox3.Text);
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@user", textBox5.Text);
                cmd.Parameters.AddWithValue("@pass", textBox6.Text);
                cmd.Parameters.AddWithValue("@img", SavePhoto());
                string Time = DateTime.Now.ToString("hh:mm:ss.f");
                string Date = DateTime.Now.ToString("dd-MM-yy");
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Date", Date);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Data updated Successfully ......... ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Data not updated !!! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
            }


            Image GetPhoto(byte[] photo)
            {
                MemoryStream ms = new MemoryStream(photo);
                return Image.FromStream(ms);
            }

        private void button2_Click_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "delete from REG where nid=@nid";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nid", textBox3.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data deleted Successfully.. ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                Reset();
            }
            else
            {
                MessageBox.Show("Data not dnserted !!!! ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void allusers_Load(object sender, EventArgs e)
            {

            }

            private void panel_register_Paint(object sender, PaintEventArgs e)
            {

            }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       
       
    }
    }

    

