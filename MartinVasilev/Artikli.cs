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
    public partial class Artikli : Form
    {
        int id;
        string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";

        public Artikli()
        {
            InitializeComponent();
            
            {
                
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Int32.Parse(comboBox2.ValueMember).ToString());
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ) { MessageBox.Show("Невалиден влез"); return; }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            string st = "INSERT INTO Proizvodi VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.Text + "')";
            //string st = "INSERT INTO Proizvodi VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";  
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            // com.Parameters.Add
            MessageBox.Show("Added");
            string str = "Select * FROM Proizvodi";
            SqlDataAdapter adapter = new SqlDataAdapter(str, con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView2.DataSource = tabela;

            con.Close();

        }

        private void Artikli_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Proizvoditel as Производител,Kolicina as Количина from Proizvodi", con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);

            this.dataGridView2.DataSource = tabela;

            /*  SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\Desktop\Database\Database.mdf;Integrated Security=True;Connect Timeout=30");
              con.Open();
              string st = "select ID,Ime as Фирма from Proizvoditeli";
              SqlDataAdapter adapter = new SqlDataAdapter(st, con);
              DataTable tabela = new DataTable();
              adapter.Fill(tabela);
              dataGridView2.DataSource = tabela;
              */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kategorija f2 = new Kategorija();
            f2.Show();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            string st = "select * from Kategorii";
            DataTable tabela = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(st,con);
            adapter.Fill(tabela);
            comboBox2.DataSource = tabela;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Proizvoditeli f = new Proizvoditeli();
            f.Show();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            string st = "select * from Proizvoditeli";
            DataTable tabela = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(st, con);
            adapter.Fill(tabela);
            comboBox1.DataSource = tabela;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни за промена на продукотот од базата?", "Предупредување", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
                con.Open();
                string stringCom = "Update Proizvodi set Proizvod = '" + textBox2.Text + "',Cena = '" + textBox3.Text + "',Kolicina = '" + textBox4.Text + "' WHERE ID = '" + id.ToString() + "' ";
                SqlCommand com = new SqlCommand(stringCom, con);
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Proizvoditel as Производител,Kolicina as Количина from Proizvodi", con);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                this.dataGridView2.DataSource = tabela;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index2 = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index2];
            textBox2.Text = selectedRow.Cells["Производ"].Value.ToString();
            textBox3.Text = selectedRow.Cells["Цена"].Value.ToString();
            textBox4.Text = selectedRow.Cells["Количина"].Value.ToString();
            id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни за бришење на продукотот од базата?", "Предупредување", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
                con.Open();
                string stringCom = "Delete from Proizvodi WHERE ID = '" + id.ToString() + "' ";
                SqlCommand com = new SqlCommand(stringCom, con);
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Proizvoditel as Производител,Kolicina as Количина from Proizvodi", con);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                this.dataGridView2.DataSource = tabela;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
