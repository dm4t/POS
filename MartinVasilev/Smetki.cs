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
    public partial class Smetki : Form
    {
        

        public Smetki()
        {
            InitializeComponent();
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            string st = "Select ID as ID ,Suma as Сума ,DDV  as ДДВ  , Den As Датум   FROM Smetki";
            SqlDataAdapter adapter = new SqlDataAdapter(st, con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;



        }

        private void Smetki_Load(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID as ID,Suma As  Сума,DDV as ДДБ,Den As Датyм from Smetki", con);       
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30"); 
                con.Open();
                string st = "Select ID as ID ,Suma as Сума ,DDV  as ДДВ  , Den As Датум   FROM Smetki Where Den BETWEEN  '" + textBox1.Text + "'and'" + textBox2.Text + "' ";

                SqlDataAdapter adapter = new SqlDataAdapter(st, con);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                dataGridView1.DataSource = tabela;
                string st1 = "Select SUM (Suma) as Сума  FROM Smetki Where Den BETWEEN  '" + textBox1.Text + "'and'" + textBox2.Text + "' ";
                SqlDataAdapter adapter1 = new SqlDataAdapter(st1, con);
                DataTable tabela1 = new DataTable();
                adapter1.Fill(tabela1);
                string sum = tabela1.Rows[0]["Сума"].ToString();
                int ddv = Int32.Parse(sum);
                float s = ddv * 0.18f;
                ddv = (int)Math.Round(s);
                textBox3.Text = tabela1.Rows[0]["Сума"].ToString();
                textBox4.Text = ddv.ToString();
                con.Close();
            }
            
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + conString + ";Integrated Security=True;Connect Timeout=30");
            string st = "Select ID as ID ,Suma as Сума ,DDV  as ДДВ  , Den As Датум   FROM Smetki";
            SqlDataAdapter adapter = new SqlDataAdapter(st, con);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
