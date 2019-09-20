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

namespace lib
{
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MANOJ-PC\SQLEXPRESS;Initial Catalog=lib;Integrated Security=True;Pooling=False");
        public add_books()
        {
            InitializeComponent();
        }

        private void add_books_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('"+ textBox1.Text  +"','"+ textBox2.Text +"','"+ textBox3.Text  +"'," + dateTimePicker1.Text  + "',"+ textBox5.Text +","+ textBox6.Text +")";
            //cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            MessageBox.Show("Books Added Successfully");

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
