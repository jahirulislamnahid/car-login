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


namespace Car
{
    public partial class Log99 : Form
    {
        public static Log99 instance;
        public TextBox tb1;

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Log99()
        {
            InitializeComponent();
            instance = this;
            tb1 = textBox1;

        }



        private void button1_Click_1(object sender, EventArgs e)
        {


            /*            MessageBox.Show("Log in successfully ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Service a1 = new Service();
                        a1.ShowDialog();*/





        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    {
                        textBox2.UseSystemPasswordChar = false;
                        break;
                    }
                default:
                    {
                        textBox2.UseSystemPasswordChar = true;
                        break;
                    }

            }
        }

      /*  private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a1 = new Form1();
            a1.ShowDialog();

        }
      */
        public void update()
        {
            SqlConnection con = new SqlConnection(cs);

            string query1 = "insert into login_details values(@nid,@Time,@Date)";
            string Time = "Time: " + DateTime.Now.ToString("hh:mm:ss.f");
            string Date = "Date: " + DateTime.Now.ToString("dd-MM-yy");
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@nid", textBox1.Text);

            cmd1.Parameters.AddWithValue("@Time", Time);
            cmd1.Parameters.AddWithValue("@Date", Date);
            con.Open();
            int a = cmd1.ExecuteNonQuery();
            con.Close();




        }


        private void button3_Click(object sender, EventArgs e)
        {


            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from REG where Nid = @nid and pass = @pass";





                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    MessageBox.Show("Log in successfully ", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    update();
                    this.Hide();
                    Crud a1 = new Crud ();
                    a1.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Log in failed ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                con.Close();





            }

            else
            {
                MessageBox.Show("Please fill the form", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your nid please....");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave_2(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter your password please....");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Crud a1 = new Crud();
            a1.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Form1 a1 = new Form1();
            a1.ShowDialog();
        }
    }
}
