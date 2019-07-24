using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace MartinVasilev
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string conString = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Database1.mdf";            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+conString+";Integrated Security=True;Connect Timeout=30");




            //  SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Database1.mdf;Integrated Security=True;Connect Timeout=30");
          //  string s = ConfigurationManager.ConnectionStrings["con"].ToString();
             SqlDataAdapter adapter = new SqlDataAdapter("Select  * from Users",con);
             DataTable tabela = new DataTable();
            adapter.Fill(tabela);
             dataGridView1.DataSource = tabela;
            
          //  MessageBox.Show(m);
        }
    }
}
