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
    public partial class prijava : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        string connectionString;

        List<string>[] uporabnikilist = new List<string>[5];
        public prijava()
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

    public List<string>[] Select()
    {
        string query = "SELECT * FROM tableinfo";

        List<string>[] list = new List<string>[3];
        uporabnikilist[0] = new List<string>();
        uporabnikilist[1] = new List<string>();
        uporabnikilist[2] = new List<string>();

        if (povezi() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                uporabnikilist[0].Add(dataReader["id"] + "");
                uporabnikilist[1].Add(dataReader["name"] + "");
                uporabnikilist[2].Add(dataReader["age"] + "");
            }

            dataReader.Close();
            odpovezi();
            return list;
        }
        else
        {
            return list;
        }
    }
    public int prijavi() // vrne 1 če je prijavilo, -5 če niso vstavlejni vsi podatki, 0, če user ne obstaja
    {
        int Count = -5;

        if (tbEmail.Text != "" && tbGeslo.Text != "")
        {
            string query = "SELECT COUNT(*) FROM uporabniki WHERE email = '" + tbEmail.Text + "' AND geslo = '" + tbGeslo.Text + "';";

            if (povezi() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");
                odpovezi();
            }
        }
        if (Count == 1)
        {
            povezi();
            string query = "SELECT * FROM uporabniki WHERE email = '" + tbEmail.Text + "' LIMIT 1";

            uporabnikilist[0] = new List<string>();
            uporabnikilist[1] = new List<string>();
            uporabnikilist[2] = new List<string>();
            uporabnikilist[3] = new List<string>();
            uporabnikilist[4] = new List<string>();

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();            

                while (dataReader.Read())
            {
                uporabnikilist[0].Add(dataReader["id"] + "");
                uporabnikilist[1].Add(dataReader["ime"] + "");
                uporabnikilist[2].Add(dataReader["priimek"] + "");
                uporabnikilist[3].Add(dataReader["email"] + "");
                uporabnikilist[4].Add(dataReader["geslo"] + "");
            }
                Properties.Settings.Default.uporabnik = uporabnikilist[3][0].ToString();
                Properties.Settings.Default.uporabnik_id = uporabnikilist[0][0].ToString();

                dataReader.Close();
            odpovezi();
            meni novoOkno = new meni();
            novoOkno.Show();
            this.Hide();
        }
        if (Count == 0)
        {
            MessageBox.Show("Uporabnik ne obstaja");
        }
        if (Count == -5)
        {
            MessageBox.Show("Niste vnesli vseh podatkov");
        }
        //MessageBox.Show(Count.ToString());

        return Count;
    }

        private void button1_Click(object sender, EventArgs e)
        {
            prijavi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registracija novoOkno = new registracija();
            novoOkno.Show();
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    

