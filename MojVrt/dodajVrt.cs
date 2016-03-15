using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace MojVrt
{
    public partial class dodajVrt : Form
    {
        public dodajVrt()
        {
            InitializeComponent();

            server = "eu-cdbr-azure-west-d.cloudapp.net";
            database = "vrt_uporabniki";
            uid = "b0e83ff9a8ec09";
            password = "b0380f00";

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        }

        SQLiteConnection povezava;
        SQLiteCommand ukaz = new SQLiteCommand();
        SQLiteDataAdapter dataadapter;
        DataSet dataset = new DataSet();
        DataTable datatable = new DataTable();

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;

        List<string>[] uporabnikilist = new List<string>[5];

        string ime;
        string visina;
        string dolzina;
        string razx;
        string razy;
        string lok_rastl;

        //lokalna baza
        private void executeQuery(string sql)
        {
            povezava = new SQLiteConnection("Data Source=baza_vrt.sqlite;Version=3;New=False;Compress=True;");
            povezava.Open();
            try
            {
                SQLiteDataReader myReader = null;
                SQLiteCommand myCommand = new SQLiteCommand(sql, povezava);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    cb_vrtovi.Items.Add(myReader["ime"].ToString());
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
        private void executeQuery2(string sql)
        {
            povezava = new SQLiteConnection("Data Source=baza_vrt.sqlite;Version=3;New=False;Compress=True;");
            povezava.Open();
            try
            {
                SQLiteDataReader myReader = null;
                SQLiteCommand myCommand = new SQLiteCommand(sql, povezava);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {                    
                     ime = myReader["ime"].ToString();
                     visina = myReader["visina"].ToString();
                     dolzina = myReader["dolzina"].ToString();
                     razx = myReader["razdelitevX"].ToString();
                     razy = myReader["razdelitevY"].ToString();
                     lok_rastl = myReader["lok_rastl"].ToString();
                }
               /* MessageBox.Show(ime);
                MessageBox.Show(visina);
                MessageBox.Show(dolzina);
                MessageBox.Show(razx);
                MessageBox.Show(razy);
                MessageBox.Show(lok_rastl);*/
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
        //Azure
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

        public void dodaj_vrt(string imeVrta)
        {
            int Count = -5;

            string sql = "SELECT * FROM vrt WHERE id='" + (cb_vrtovi.SelectedIndex + 1) + "';";
            executeQuery2(sql);

            string query = "SELECT COUNT(*) FROM vrtovi WHERE ime = '" + imeVrta + "';";

            if (povezi() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                Count = int.Parse(cmd.ExecuteScalar() + "");
                odpovezi();
            }

            if (Count == 0)
            {
                nonQuery("INSERT INTO vrtovi (uporabnik_id,ime,x,y,razx,razy,podatki) VALUES (" + Properties.Settings.Default.uporabnik_id.ToString()+",'"+ ime +"',"+dolzina+ "," + visina + "," + razx + "," + razy + ",'" + lok_rastl + "');");//tu pridejo vrednosti iz lokalne baze
                MessageBox.Show("Vrt je bil dodan v oblak.");
            }
            else if (Count == -5)
            {
                MessageBox.Show("Povezava do baze nemogoča. Preveri internetno povezavo.");
            }
            else
            {
                MessageBox.Show("Vrt je že v oblaku.");
            }
        }

        private void dodajVrt_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            meni novoOkno = new meni();
            novoOkno.Show();
            this.Hide();
        }

        private void dodajVrt_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM vrt;";
            executeQuery(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string ime_vrta = cb_vrtovi.SelectedText;
            dodaj_vrt(ime_vrta);
        }
    }
}
