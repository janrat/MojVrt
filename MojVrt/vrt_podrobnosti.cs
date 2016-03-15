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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MojVrt
{
    public partial class vrt_podrobnosti : Form
    {
        public vrt_podrobnosti()
        {
            InitializeComponent();
        }
        SQLiteConnection povezava;
        SQLiteCommand ukaz = new SQLiteCommand();
        SQLiteDataAdapter dataadapter;
        DataSet dataset = new DataSet();
        DataTable datatable = new DataTable();

        public void executeNonQuery(string sql)
        {
            povezava = new SQLiteConnection("Data Source=baza_vrt.sqlite;Version=3;New=False;Compress=True;");
            povezava.Open();
            ukaz = povezava.CreateCommand();
            ukaz.CommandText = sql;
            ukaz.ExecuteNonQuery();
            povezava.Close();
        }
        string idOdRastline;
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
                    idOdRastline = myReader["id"].ToString();
                    label_povpKaljivost.Text = myReader["pov_cas_kaljivosti"].ToString();
                    label_razdalja.Text = myReader["razdalja_sajenja"].ToString();
                    label_sajenja.Text = myReader["setev"].ToString();
                    label_presajanja.Text = myReader["presajanje"].ToString();
                    label_pobiranja.Text = myReader["pobiranje"].ToString();
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
                    if (myReader["odnos"].ToString() == "1")
                    {
                        label_dobriSosedje.Text = label_dobriSosedje.Text + myReader["rastlina2_id"].ToString() + ", ";
                    }
                    if (myReader["odnos"].ToString() == "0")
                    {
                        label_slabiSosedje.Text = label_slabiSosedje.Text + myReader["rastlina2_id"].ToString() + ", ";
                    }
                }

            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
        private void executeQuery3(string sql)
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
                    string rastline = myReader["lok_rastl"].ToString();
                    string[] ids;
                    ids = rastline.Split(',');
                   

                    //string[] posamezne_rastline;
                    for (int i=0;i<ids.Length;i++)
                    {

                        if(!cb_rastline.Items.Contains(ids[i]))
                        {
                            if (ids[i] == "0")
                            {
                                break;
                            }
                            if (ids[i] == "")
                            {
                                break;
                            }

                            string sql1 = "SELECT ime FROM rastline WHERE id=" + ids[i] + ";";
                            executeQuery4(sql1);

                        }
                       
                    }
                    string slabiSosedje = label_slabiSosedje.Text;
                    

                }

            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
        private void executeQuery4(string sql)
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
                    if (!cb_rastline.Items.Contains(myReader["ime"].ToString()))
                    {
                        cb_rastline.Items.Add(myReader["ime"].ToString());
                    }
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }
        private void dodajVrtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dodajVrt novoOkno = new dodajVrt();
            novoOkno.Show();
            this.Hide();
        }

        private void vrt_podrobnosti_Load(object sender, EventArgs e)
        {
            label5.Text = Properties.Settings.Default.vrt.ToString();
            string sql = "SELECT lok_rastl FROM vrt WHERE ime='" + Properties.Settings.Default.vrt.ToString() + "';";
            executeQuery3(sql);
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://api.sunrise-sunset.org/json?lat=46.3622743&lng=15.1106582&date=today");
                //MessageBox.Show(json.ToString());
                string valueOriginal = Convert.ToString(json);
                string ure = valueOriginal.Substring(45, 1);
                string ostalo = valueOriginal.Substring(47, 2);
                int h1 = DateTime.Parse(ure + "pm").Hour - 1;
                int h2 = DateTime.Parse(ure + "pm").Hour;

                //MessageBox.Show(str);
                label_zalivanje.Text = h1 + ":" + ostalo;

                TimeSpan start = new TimeSpan(h1, 0, 0); //10 o'clock
                TimeSpan end = new TimeSpan(h2, 0, 0); //12 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;

                if ((now > start) && (now < end))
                {
                    MessageBox.Show("Zdaj je primeren čas za zalivanje vrta.");
                }
            }
        }

        private void vrt_podrobnosti_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cb_rastline_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_dobriSosedje.Text = "";
            label_slabiSosedje.Text = "";
            int izbrana_rastlina = cb_rastline.SelectedIndex + 1;
            string sql = "SELECT * FROM rastline WHERE ime='" + cb_rastline.SelectedItem.ToString() + "';";
            executeQuery(sql);

            string sql2 = "SELECT * FROM sosedje WHERE rastlina1_id=" + idOdRastline + ";";
            executeQuery2(sql2);

            string sajenje = label_sajenja.Text;
            string presajanje = label_presajanja.Text;
            string pobiranje = label_pobiranja.Text;
            string slabiSosedje = label_slabiSosedje.Text;
            string dobriSosedje = label_dobriSosedje.Text;

            label_sajenja.Text = sajenje.Replace("10", " oktober")
                            .Replace("11", " november").Replace("12", " december").Replace("1", " januar").Replace("2", " februar")
                            .Replace("3", " marec").Replace("4", " april").Replace("5", " maj").Replace("6", " junij")
                            .Replace("7", " julij").Replace("8", " avgust").Replace("9", " september");

            label_presajanja.Text = presajanje.Replace("10", " oktober")
                            .Replace("11", " november").Replace("12", " december").Replace("1", " januar").Replace("2", " februar")
                            .Replace("3", " marec").Replace("4", " april").Replace("5", " maj").Replace("6", " junij")
                            .Replace("7", " julij").Replace("8", " avgust").Replace("9", " september");

            label_pobiranja.Text = pobiranje.Replace("10", " oktober")
                            .Replace("11", " november").Replace("12", " december").Replace("1", " januar").Replace("2", " februar")
                            .Replace("3", " marec").Replace("4", " april").Replace("5", " maj").Replace("6", " junij")
                            .Replace("7", " julij").Replace("8", " avgust").Replace("9", " september");

            label_slabiSosedje.Text = slabiSosedje.Replace("10", " Fižol nizki")
                            .Replace("11", " Fižol visoki").Replace("12", " Grah").Replace("13", " Jajčevec").Replace("14", " Kitajsko zelje").Replace("15", " Koleraba")
                            .Replace("16", " Kolerabica").Replace("17", " Korenček").Replace("18", " Kumare").Replace("19", " Motovilec").Replace("20", " Ohrovt")
                            .Replace("21", " Paprika").Replace("22", " Paradižnik").Replace("23", " Peteršilj").Replace("24", " Por").Replace("25", " Radič")
                            .Replace("26", " Rdeča pesa").Replace("27", " Redkvica").Replace("28", " Repa").Replace("29", " Sladka koruza").Replace("30", " Solata")
                            .Replace("31", " Špinača").Replace("32", " Zelena gomoljna").Replace("33", " Zelje").Replace("1", " Blitva").Replace("2", " Bob")
                            .Replace("3", " Brokoli").Replace("4", " Brstični Ohrovt").Replace("5", " Bučke").Replace("6", " Buče")
                            .Replace("7", " Cvetača").Replace("8", " Čebula").Replace("9", " Endivija");

            label_dobriSosedje.Text = dobriSosedje.Replace("10", " Fižol nizki")
                .Replace("11", " Fižol visoki").Replace("12", " Grah").Replace("13", " Jajčevec").Replace("14", " Kitajsko zelje").Replace("15", " Koleraba")
                .Replace("16", " Kolerabica").Replace("17", " Korenček").Replace("18", " Kumare").Replace("19", " Motovilec").Replace("20", " Ohrovt")
                .Replace("21", " Paprika").Replace("22", " Paradižnik").Replace("23", " Peteršilj").Replace("24", " Por").Replace("25", " Radič")
                .Replace("26", " Rdeča pesa").Replace("27", " Redkvica").Replace("28", " Repa").Replace("29", " Sladka koruza").Replace("30", " Solata")
                .Replace("31", " Špinača").Replace("32", " Zelena gomoljna").Replace("33", " Zelje").Replace("1", " Blitva").Replace("2", " Bob")
                .Replace("3", " Brokoli").Replace("4", " Brstični Ohrovt").Replace("5", " Bučke").Replace("6", " Buče")
                .Replace("7", " Cvetača").Replace("8", " Čebula").Replace("9", " Endivija");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            izbor_vrta novoOkno = new izbor_vrta();
            novoOkno.Show();
            this.Hide();
        }
    }
}