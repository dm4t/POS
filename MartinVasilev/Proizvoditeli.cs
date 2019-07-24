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

namespace MartinVasilev
{
    public partial class Proizvoditeli : Form
    {

        public Proizvoditeli()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string st = "INSERT INTO Proizvoditeli VALUES ('" + textBox1.Text + "','"+textBox2.Text+"')";
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Додадено");
            con.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,Ime as Производител,Drzava as Држава from Proizvoditeli", con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "") { MessageBox.Show("Неавалидна информација"); return; }
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();       
            string sti = textBox3.Text;
            MessageBox.Show(sti);
            string st = "DELETE FROM Proizvoditeli WHERE Ime = '" + sti + "'";
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Производителот е избришана");
            con.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,Ime as Производител,Drzava as Држава from Proizvoditeli", con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            
        }

        private void Proizvoditeli_Load(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,Ime as Производител,Drzava as Држава from Proizvoditeli", con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            con.Open();
            con.Close();

        }
    }
}
