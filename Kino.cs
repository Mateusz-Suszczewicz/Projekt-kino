using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Win32;

namespace kino
{
    internal class kinoDB
    {
        private decimal wersja = 0.3m;
        // TODO: Przebudować metod na mechanizm Dappera
        // TODO: PRZEMYŚLEĆ: Dodać konstruktor który sprawdzi: 1 czy istnijej już ustalone połaczenie; 2 sprawdzi wersję w bazie danych.

        private string? connectionString;

        public bool PolaczenieDoBazyZRejestru()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Kino");
            if (key != null) {
                string server = key.GetValue("server").ToString();
                string loginMethod = key.GetValue("loginMethod").ToString();
                string database = key.GetValue("database").ToString();
                string login = key.GetValue("login").ToString();
                string passowrd = key.GetValue("passowrd").ToString();
                connectionString = loginMethod == "1" ? $"Data Source={server}; Database={database}; Integrated Security=SSPI;" : $"Data Source={server}; Initial Catalog = {database}; User ID={login}; Password={passowrd}";
                return true;
            }
            return false;

        }

        /// <summary>
        /// method <c>ConnectionString</c> Ustawienie linku do połączenie do bazy danych 
        /// </summary>
        /// <param name="server">Adres serwera do którego chcemy się połączyć</param>
        /// <param name="loginMethod">Metoda logowania: 1 - Logowanie zintegrowane 2 - poprzez autoryzację SQL</param>
        /// <param name="database">Baza danych do której się chcemy podpiąć</param>
        /// <param name="login">Login użytkownika bazy danych</param>
        /// <param name="passowrd">Hasło użytkownika bazy danych</param>
        /// <returns>Zwraca TRUE jesli połączenie się powiodło i FALSE jeśli się nie powiodło</returns>
        public bool ConnectionString(string server, int loginMethod, string database, string login = "0", string passowrd = "0")
        {
            string conString = loginMethod == 1 ? $"Data Source={server}; Database={database}; Integrated Security=SSPI;" : $"Data Source={server}; Initial Catalog = {database}; User ID={login}; Password={passowrd}";
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string query = $"SELECT database_id FROM sys.databases WHERE Name = '{database}'";
                var idDatabase = conn.ExecuteScalar<int>(query);
                if (idDatabase != 0)
                {
                    connectionString = conString;
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Kino");
                    key.SetValue("server", server);
                    key.SetValue("loginMethod", loginMethod.ToString());
                    key.SetValue("database", database);
                    key.SetValue("login", login);
                    key.SetValue("passowrd", passowrd);
                    key.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// method <c>CreateTable</c> Tworzy tabele w bazie danych zalecane jednokrotne uruchomienie
        /// </summary>
        public string CreateTable(int wymuszenieAktualizacji = 0) // TODO: Przygotować mechanizm pod sprawdzanie czy poszczególne tabele istnieją
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<string> sqlList = new List<string>() {
                "create.sql",
                "addBooking.sql",
                "addCategory.sql",
                "addFilm.sql",
                "addSeance.sql",
                "addSeat.sql",
                "addSR.sql",
                "addUser.sql",
                "FilmListV.sql",
                "OperCodeV.sql",
            };
            //sprawdzenie istnienia bazy konfiguracujnej
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Config'";
            var tableList = conn.ExecuteScalar<string>(query);
            if (tableList == "config")
            {
                //sprawdzenie wersji w bazie 
                query = "SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 1";
                var wersjaWBazie = conn.ExecuteScalar<decimal>(query);
                //aktualizacja sktyptów bez tworzenia bazy danych 
                if(wersjaWBazie <= wersja || wymuszenieAktualizacji == 1)
                {
                    sqlList.Remove("create.sql");
                    foreach (string s in sqlList)
                    {
                        FileInfo file = new FileInfo($"SQL/{s}");
                        string script = file.OpenText().ReadToEnd();
                        try
                        {
                            conn.Query(script);
                        }
                        catch (Exception ex){ return s.ToString() + ex.Message; }
                    }
                    //aktualizacja wersji w bazie danych
                    query = $"UPDATE dbo.config SET Conf_Wartosc = '{wersja}' WHERE Conf_ID  = 1";
                    try
                    {
                        conn.Query(query);
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return "zakończono aktualizację skryptów";
                }
            }
            else
            {
                //Wgranie struktury bazy dnaych wraz z wszystkimi skryptami
                foreach (string s in sqlList)
                {
                    FileInfo file = new FileInfo($"SQL/{s}");
                    string script = file.OpenText().ReadToEnd();
                    try
                    {
                        conn.Query(script);
                    }
                    catch (Exception ex) { return "Błąd tworzenia: " + s.ToString() + ex.Message; }
                }
                //aktualizacja wersji w bazie danych
                query = $"UPDATE dbo.config SET Conf_Wartosc = '{wersja}' WHERE Conf_ID  = 1";
                try
                {
                    conn.Query(query);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "Zakończono tworzenie struktury bazy danych";
            }
            return "Nie wykonano żadnej operacji"; 
        }

        /// <summary>
        /// method <c>ShowFilms</c> wyświetlenie wszystkich filmów
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ShowFilms()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM dbo.FIlmListV";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// method <c>ShowCode</c> wyświetlenie wszytskich operatorów z kodami 
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ShowCode()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM dbo.OperCodeV";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            conn.Close();
            return reader;
        }

        /// <summary>
        /// method <c>DodanieFilmu</c> Umozliwia dodanie filmu lub edycję już istniejącego. Jesli do metody zostanie przekazane ID filmu to film w bazie zostanie zaktualizowany o WSZYSTKIE wprowadzone dane
        /// </summary>
        /// <param name="tytul">Tytuł filmu</param>
        /// <param name="opis">OPis filmu</param>
        /// <param name="DataDodania">Data dodania dilmu </param>
        /// <param name="category">Kategoria do której należy film</param>
        /// <param name="duration">Czas trwania filmu w minutach</param>
        /// <param name="srcPicture">Link do obrazka </param>
        /// <param name="filmID"><ID filmu domyslnie 0/param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieFilmu(string tytul, string opis, DateTime DataDodania, int category, int duration, string srcPicture, int filmID = 0) //TODO: Do obsłużenia są obrazki
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addFilm", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = tytul;
            cmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = opis;
            cmd.Parameters.Add("@DataDodania", SqlDbType.DateTime).Value = DataDodania;
            cmd.Parameters.Add("@Category", SqlDbType.Int).Value = category;
            cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;
            cmd.Parameters.Add("@Duration", SqlDbType.VarChar).Value = srcPicture;
            if (filmID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = filmID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            var result = returnParameter.Value;
            conn.Close();
            return result.ToString();
        }

        /// <summary>
        /// method <c>DodanieOperatora</c> Umożliwia dodanie operatora lub edycję już istniejącego.
        /// </summary>
        /// <param name="Login">Login operatora</param>
        /// <param name="Typ">Typ operatora: 1 - kierownik; 2- klient</param>
        /// <param name="operID">Id operatora</param>
        /// <param name="Haslo"> hasło operatora</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieOperatora(string Login, int Typ, int operID = 0, string? Haslo = "")
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addOper", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Haslo;
            cmd.Parameters.Add("@typ", SqlDbType.Int).Value = Typ;
            if (operID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = operID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieSali</c> Umożliwia dodanie sali lub jej edycję
        /// </summary>
        /// <param name="numberSR">Numer sali</param>
        /// <param name="contentSR">opis sali</param>
        /// <param name="SRID">Id sali</param>
        /// <param name="status">status sali: 0 - sala aktywna; 1 - sala nieaktywna</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieSali(int numberSR, string contentSR, int SRID = 0, int status = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addSR", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nr", SqlDbType.Int).Value = numberSR;
            cmd.Parameters.Add("@content", SqlDbType.VarChar).Value = contentSR;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
            if (SRID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = SRID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieMiejsca</c> Umożliwia dodanie miejsca na sali lub jego edycję 
        /// </summary>
        /// <param name="srID">ID Sali </param>
        /// <param name="numberSeat">numer fotela</param>
        /// <param name="rowSeat">rząd foteli</param>
        /// <param name="SeatID">ID fotela</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieMiejsca(int srID, int numberSeat, int rowSeat, int SeatID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addSeat", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@srid", SqlDbType.Int).Value = srID;
            cmd.Parameters.Add("@nr", SqlDbType.VarChar).Value = numberSeat;
            cmd.Parameters.Add("@row", SqlDbType.Int).Value = rowSeat;
            if (SeatID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = SeatID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieKategorii</c> Umożliwia dodanie miejsca na sali lub jego edycję 
        /// </summary>
        /// <param name="name">nazwa kategorii</param>
        /// <param name="CatId">ID kategorii</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieKategorii(string name, int CatId = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            if (CatId != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = CatId;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieSeansu</c> Umożliwia dodanie seansu do wyświetlenia
        /// </summary>
        /// <param name="filmID">ID filmu</param>
        /// <param name="SRID"> ID sali</param>
        /// <param name="dataEmisji">data rozpoczęcia seansu</param>
        /// <param name="dataKonca">data zakończenia seansu</param>
        /// <param name="SEID">ID seansu</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieSeansu(int filmID, int SRID, DateTime dataEmisji, DateTime dataKonca, int SEID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addSeance", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@filmID", SqlDbType.Int).Value = filmID;
            cmd.Parameters.Add("@srID", SqlDbType.Int).Value = SRID;
            cmd.Parameters.Add("@dataEmisji", SqlDbType.DateTime).Value = dataEmisji;
            cmd.Parameters.Add("@datakonca", SqlDbType.DateTime).Value = dataKonca;
            if (SEID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = SEID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieBiletu</c> Umożliwia dodanie biletu lub jego edycję
        /// </summary>
        /// <param name="operID">ID operatora</param>
        /// <param name="seatID">ID fotela</param>
        /// <param name="SeID">Id seansu</param>
        /// <param name="type">typ biletu</param>
        /// <param name="dataZakupu">data zakupu</param>
        /// <param name="Code">kod promocyjny</param>
        /// <param name="bookID">id biletu</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieBiletu(int operID, int seatID, int SeID, int type, DateTime dataZakupu, int Code = 0, int bookID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addBooking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OperId", SqlDbType.Int).Value = operID;
            cmd.Parameters.Add("@SeatId", SqlDbType.Int).Value = seatID;
            cmd.Parameters.Add("@SeId", SqlDbType.Int).Value = SeID;
            cmd.Parameters.Add("@Code", SqlDbType.Int).Value = Code;
            cmd.Parameters.Add("@type", SqlDbType.Int).Value = type;
            cmd.Parameters.Add("@dataZakupu", SqlDbType.DateTime).Value = dataZakupu;
            if (bookID != 0)
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = bookID;
            }
            var returnParameter = cmd.Parameters.Add("@r", SqlDbType.VarChar, 300);
            returnParameter.Direction = ParameterDirection.Output;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                conn.Close();
                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        
        public string test()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "addCategory11";
            var values = new { name = "akcja" };
            var results = conn.ExecuteScalar<string>(procedure, values,  commandType: CommandType.StoredProcedure);
            return results;
        }
    }
}
