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
    public partial class issue_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MANOJ-PC\SQLEXPRESS;Initial Catalog=lib;Integrated Security=True;Pooling=False");
        public issue_books()
        {
            InitializeComponent();
        }

        private void txt_enrollment_Click(object sender, EventArgs e)
        {
            int i = 0;   
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where student_enrollment_no'"+ txt_enrollment.Text +"'";
                //cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
         //   da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("this Enrollment not found");
            }
            else
            {


                foreach (DataRow dr in dt.Rows)
                {
                    txt_studentname.Text = dr["student_name"].ToString();
                    txt_studentdept.Text = dr["student_depart"].ToString();                   
                    txt_studentsem.Text = dr["student_sem"].ToString();
                    txt_studentcontact.Text = dr["student_contact"].ToString();
                    txt_studentemail.Text = dr["student_email"].ToString(); 
                   
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void issue_books_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Issued Successfully");
        }
    }
}
