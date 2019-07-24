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
    public partial class Smetka : Form
    {
        string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
        int id;
        

        public Smetka()
        {
            InitializeComponent();       
   
        }

        private void Smetka_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet1.Kategorii' table. You can move, or remove it, as needed.
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Kolicina as Количина from Proizvodi", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            if (textBox2.Text != null)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Kolicina as Количина from Proizvodi", con);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }   
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try


            {
               
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
                int index1 = e.RowIndex;
                con.Open();
                DataGridViewRow selectedRow = dataGridView1.Rows[index1];
                string st = selectedRow.Cells["Производ"].Value.ToString();
                int cena1 = Int32.Parse(selectedRow.Cells["Цена"].Value.ToString());
                id = Int32.Parse(selectedRow.Cells["ID"].Value.ToString());
                int kolicina = Int32.Parse(selectedRow.Cells["Количина"].Value.ToString()) - 1;
                dataGridView2.Rows.Add(id,st, cena1);
                label4.Text = (Int32.Parse(label4.Text) + cena1).ToString();
                //string stringCom = " Update Proizvodi Set Kolicina = '" + kolicina.ToString() + "' where ID = '" + id.ToString() + "'";
                string stringCom = " Update Proizvodi Set Kolicina = Kolicina - 1  where ID = '" + id.ToString() + "'";

                SqlCommand com = new SqlCommand(stringCom,con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { }
        }

       
        

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            int ddv = Int32.Parse(label4.Text);
            float s = ddv * 0.18f;
            ddv = (int)Math.Round(s);
            
            
            string st = "Insert into Smetki(Suma,DDV) Values ('" + label4.Text + "','" + ddv.ToString() + "')";
            SqlCommand com = new SqlCommand(st, con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Наплати");
            dataGridView2.Rows.Clear();
            label4.Text = "0";
            SqlDataAdapter adapter = new SqlDataAdapter("select ID as ID, Proizvod as Производ,Kategorija as Категорија,Cena as Цена,Kolicina as Количина from Proizvodi", con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
                con.Open();
                int index2 = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[index2];
                int cena2 = Int32.Parse(selectedRow.Cells["Цена"].Value.ToString());
                id = Int32.Parse(selectedRow.Cells["ID1"].Value.ToString());
                dataGridView2.Rows.RemoveAt(index2);
                label4.Text = (Int32.Parse(label4.Text) - cena2).ToString();
                string stringCom = " Update Proizvodi Set Kolicina = Kolicina+1  where ID = '" + id.ToString() + "'";
                SqlCommand com = new SqlCommand(stringCom, con);
                com.ExecuteNonQuery();
                con.Close();



            
        }
    }
}
