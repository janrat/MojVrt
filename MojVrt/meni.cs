using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MojVrt
{
    public partial class meni : Form
    {
        public meni()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Pozdravljen " + Properties.Settings.Default.uporabnik.ToString() + " v aplikaciji MojVrt!";
        }

        private void meni_Load(object sender, EventArgs e)
        {
            label1.Text = "Pozdravljen " + Properties.Settings.Default.uporabnik.ToString() + " v aplikaciji MojVrt!";
        }

        private void meni_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dodajVrt novoOkno = new dodajVrt();
            novoOkno.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            izbor_vrta novoOkno = new izbor_vrta();
            novoOkno.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 novoOkno = new Form1();
            novoOkno.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            prijava novoOkno = new prijava();
            novoOkno.Show();
            this.Hide();
        }
    }
}
