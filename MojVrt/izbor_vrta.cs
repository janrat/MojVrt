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
    public partial class izbor_vrta : Form
    {
        public izbor_vrta()
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

        List<string>[] oVrtu = new List<string>[8];

        public void executeNonQuery(string sql)
        {
            povezava = new SQLiteConnection("Data Source=baza_vrt.sqlite;Version=3;New=False;Compress=True;");
            povezava.Open();
            ukaz = povezava.CreateCommand();
            ukaz.CommandText = sql;
            ukaz.ExecuteNonQuery();
            povezava.Close();
        }
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
        public void prenesiVrt()
        {
            povezi();
            string query = "SELECT DISTINCT(ime),id,x,y,razx,razy,podatki FROM vrtovi WHERE uporabnik_id = " + Properties.Settings.Default.uporabnik_id.ToString() + ";";

            oVrtu[0] = new List<string>();
            oVrtu[1] = new List<string>();
            oVrtu[2] = new List<string>();
            oVrtu[3] = new List<string>();
            oVrtu[4] = new List<string>();
            oVrtu[5] = new List<string>();
            oVrtu[6] = new List<string>();
            oVrtu[7] = new List<string>();

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int x = 0;
            while (dataReader.Read())
            {
                oVrtu[0].Add(dataReader["id"] + "");
                oVrtu[1].Add(dataReader["ime"] + "");
                oVrtu[2].Add(dataReader["x"] + "");
                oVrtu[3].Add(dataReader["y"] + "");
                oVrtu[4].Add(dataReader["razx"] + "");
                oVrtu[5].Add(dataReader["razy"] + "");
                oVrtu[6].Add(dataReader["podatki"] + "");                
                x++;
            }
            //podatke iz oVrtu vpiši v lokalno bazo
            for (int i = 0; i < x; i++)
            { 
                if(!cb_vrtovi.Items.Contains(oVrtu[1][i]))
                {
                    string sql = "INSERT INTO vrt (ime, dolzina, visina, razdelitevX, razdelitevY, lok_rastl) VALUES('" + oVrtu[1][i] + "', " + oVrtu[2][i] + ", " + oVrtu[3][i] + ", " + oVrtu[4][i] + ", " + oVrtu[5][i] + ", '" + oVrtu[6][i] + "'); ";
                    executeNonQuery(sql);
                }               
                               
            }
            cb_vrtovi.Items.Clear();
            string sql1 = "SELECT * FROM vrt;";
            executeQuery(sql1);
            MessageBox.Show("Uspešno ste prenesli vrtove iz oblaka.");

            dataReader.Close();
            odpovezi();
        }

        private void izbor_vrta_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void izbor_vrta_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM vrt;";
            executeQuery(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prenesiVrt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.vrt = cb_vrtovi.SelectedItem.ToString();
            vrt_podrobnosti novoOkno = new vrt_podrobnosti();
            novoOkno.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            meni novoOkno = new meni();
            novoOkno.Show();
            this.Hide();
        }
    }
}
