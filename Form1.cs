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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       /* private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }*/
        private void button2_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Regi a1 = new Regi();
            a1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Log99 a1 = new Log99();
            a1.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}