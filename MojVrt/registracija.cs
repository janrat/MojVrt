using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MojVrt
{
    public partial class registracija : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        string connectionString;

        List<string>[] uporabnikilist = new List<string>[5];
        public registracija()
        {
            InitializeComponent();

            server = "eu-cdbr-azure-west-d.cloudapp.net";
            database = "vrt_uporabniki";
            uid = "b0e83ff9a8ec09";
            password = "b0380f00";

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }
        public bool povezi()
        {
            connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Povezava z serverjem nemogoča.");
                        break;

                    case 1045:
                        MessageBox.Show("Napačni credential-i.");
                        break;
                }
                return false;
            }
        }

        private bool odpovezi()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void nonQuery(string query)
        {
            if (povezi() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                odpovezi();
            }
        }       

        public int registriraj() // vrne 0 če je registriralo, -5 če niso vstavlejni vsi podatki, 0+n, če user že obstaja
        {
            int Count = -5;

            if (tbIme.Text != "" && tbPriimek.Text != "" && tbEmail.Text != "" && tbGeslo.Text != "")
            {
                string query = "SELECT COUNT(*) FROM uporabniki WHERE email = '" + tbEmail.Text + "';";

                if (povezi() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    Count = int.Parse(cmd.ExecuteScalar() + "");
                    odpovezi();
                }
            }

            if (Count == 0)
            {            
                nonQuery("INSERT INTO uporabniki (ime,priimek,email,geslo) VALUES ('" + tbIme.Text + "','" + tbPriimek.Text + "','" + tbEmail.Text + "','" + tbGeslo.Text + "')");
                prijava novoOkno = new prijava();
                novoOkno.Show();
                this.Close();
                MessageBox.Show("Registracija uspešna");
            }
            if(Count == -5)
            {
                MessageBox.Show("Niste vnesli vseh podatkov");
            }
            if (Count > 0)
            {
                MessageBox.Show("Uporabnik že obstaja");
            }

            //MessageBox.Show(Count.ToString());

            return Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prijava novoOkno = new prijava();
            novoOkno.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registriraj();
        }

        private void registracija_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
