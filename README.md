Povezava do metro aplikacije, ki jo je naredil Jaka Jenko:</br> https://github.com/JakaJenko/Moj-Vrt </br>
Povezava do vodiča, kako upravljati Microsoft Aure, ki ga je spisal Matic Šincek:</br> https://azurehowto101.wordpress.com/uvod-v-microsoft-azure/ </br>
<h3>Prva instalacija:</h3>
<ul>
        <li>Ustvarimo nov projekt > Windows Form Aplication</li>
        <li>V projekt dodamo Nuget paketa imenovana Sqlite-net in SQlitePCL</li>
        <li>Na začetku kjer so vključene vrstice dodamo: using System.Data.SQLite;</li>
</ul>
</br>Povezava na lokalno podatkovno bazo (SQlite):

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
</br>
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

</br>Klicanje funkcij za lokalno podatkovno bazo:

        string sql = "SELECT * FROM ime_tabele;";
        executeQuery(sql);
        
</br>API za dobivanje podatkov sončnega zahoda:

         using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("http://api.sunrise-sunset.org/json?lat=46.3622743&lng=15.1106582&date=today");
                string valueOriginal = Convert.ToString(json);
                string ure = valueOriginal.Substring(45, 1); // dobi podatke od 45 znaka za 1 znak naprej
                string ostalo = valueOriginal.Substring(47, 2); // dobi podatke od 47 znaka za 2 znak naprej
                int h = DateTime.Parse(ure + "pm").Hour; // pretvori iz 12h formata v 24h format
            }
</br>
Povezava na Azure:

        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        
        server = ""; //ime serverja npr. eu-cdbr-azure-west-d.cloudapp.net
        database = "ime_baze";
        uid = "xxxxxxxx";
        password = "xxxxxx";
        
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
</br>
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

</br>Urejanje podatkovne baze na Azuru:

        public void nonQuery(string query)
        {
            if (povezi() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                odpovezi();
            }
        }  
