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
    public partial class Kategorija : Form
    {
        

        public Kategorija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string st = "INSERT INTO Kategorii VALUES ('" + textBox1.Text + "')";
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Додадено");
            con.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Kategorija as Категорија from Kategorii", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string sti = textBox2.Text;
            MessageBox.Show(sti);
            string st = "DELETE FROM Kategorii WHERE Kategorija = '" + sti + "'";
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Категоријата е избришана");
            con.Close();   
            SqlDataAdapter adapter = new SqlDataAdapter("Select Kategorija as Категорија from Kategorii", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

        private void Kategorija_Load(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter("Select Kategorija as Категорија from Kategorii", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
             dataGridView1.DataSource = table;
            }
    }
}
