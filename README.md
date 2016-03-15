Prva instalacija:
        -Ustvarimo nov projekt > Windows Form Aplication
        -V projekt dodamo Nuget paketa imenovana Sqlite-net in SQlitePCL
        -Na začetku kjer so vključene vrstice dodamo: using System.Data.SQLite;

Povezava na lokalno podatkovno bazo (SQlite):
        SQLiteConnection povezava;
        SQLiteCommand ukaz = new SQLiteCommand();
        SQLiteDataAdapter dataadapter;
        DataSet dataset = new DataSet();
        DataTable datatable = new DataTable();
        
Urejanje lokalne podatkovne baze:
        public void executeNonQuery(string sql)
        {
        povezava = new SQLiteConnection("Data    Source=baza_vrt.sqlite;Version=3;New=False;Compress=True;");
            povezava.Open();
            ukaz = povezava.CreateCommand();
            ukaz.CommandText = sql;
            ukaz.ExecuteNonQuery();
            povezava.Close();
        }

Branje iz lokalne podatkovne baze:
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
                        //kar hočete narditi s podatki
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
        }

klicanje funkcij za lokalno podatkovno bazo:
        string sql = "SELECT * FROM ime_tabele;";
        executeQuery(sql);
        
API za dobivanje podatkov sončnega zahoda:
         using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://api.sunrise-sunset.org/json?lat=46.3622743&lng=15.1106582&date=today");
                string valueOriginal = Convert.ToString(json);
                string ure = valueOriginal.Substring(45, 1); // dobi podatke od 45 znaka za 1 znak naprej
                string ostalo = valueOriginal.Substring(47, 2); // dobi podatke od 47 znaka za 2 znak naprej
                int h = DateTime.Parse(ure + "pm").Hour; // pretvori iz 12h formata v 24h format
            }

Povezava na Azure:
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        server = "eu-cdbr-azure-west-d.cloudapp.net";
        database = "vrt_uporabniki";
        uid = "b0e83ff9a8ec09";
        password = "b0380f00";
        
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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

Prekinitev povezave:
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

Urejanje podatkovne baze na Azuru:
        public void nonQuery(string query)
        {
            if (povezi() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                odpovezi();
            }
        }  
