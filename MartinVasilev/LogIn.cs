using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartinVasilev
{
    public partial class LogIn : Form
    {
        Smetka smetka;
        public LogIn()
        {
            InitializeComponent();       
            
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.FormClosing += Out;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smetka = new Smetka();
            smetka.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Artikli Ar = new Artikli();
            Ar.Show();
        }


        private void Out(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Smetki f = new Smetki();
            f.Show();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            
        }
    }
}
