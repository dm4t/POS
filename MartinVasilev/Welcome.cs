using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace MartinVasilev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += Out;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30"); 
            con.Open();

            string login =  "select count(*) from Users where Username='" + textBox1.Text + "' and PW= '" + textBox2.Text + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(login,con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
                
                if (dt.Rows[0][0].ToString() == "1")
                {
                
                LogIn FormLogIn = new LogIn();
                FormLogIn.Show();
                this.Hide();
                con.Close();

            }
                else
                {
                    MessageBox.Show("Грешка");
                }
               
           
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            LogIn FormLogIn = new LogIn();
            FormLogIn.Show();
            this.Hide();
            
        }
        private void Out(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 m = new Form2();
            m.Show();
            
        }

       
    }
    }

