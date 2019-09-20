using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace lib
{
    public partial class add_student_info : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MANOJ-PC\SQLEXPRESS;Initial Catalog=lib;Integrated Security=True;Pooling=False");
        
        string wanted_path;
        string pwd = Class1.GetRandomPassword(20); 

        public add_student_info()
        {
            InitializeComponent();
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String img_path;
                File.Copy(openFileDialog1.FileName, wanted_path + "\\student_images\\" + pwd + ".jpg");
                img_path = "student_images\\" + pwd + ".jpg";

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into student_info values('" + textBox1.Text + "','" + img_path.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
              //  cmd.EndExecuteNonQuery();
                con.Close();
                MessageBox.Show("record inserted successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            DialogResult result = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files(*.jpeg)| *.jpeg | PNF Files(*.png) | *.png | JPG Files(*.jpg) | *.jpg | GIF Files(*.gif)|*.gif";
if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
