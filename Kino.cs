using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Dapper;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kino
{
    internal class kinoDB
    {
        private decimal wersja = 0.4m;
        
        // TODO: PRZEMYŚLEĆ: Dodać konstruktor który sprawdzi: 1 czy istnijej już ustalone połaczenie; 2 sprawdzi wersję w bazie danych.
        // TODO:  

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
                "V04.sql",
                "addBooking.sql",
                "addCategory.sql",
                "addFilm.sql",
                "addSeance.sql",
                "addSeat.sql",
                "addSR.sql",
                "addOper.sql",
                "addCategoryToFilm.sql",
                "addPicture.sql",
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
                if(wersjaWBazie == 0.4m)
                {
                    sqlList.Remove("V04.sql");
                }
                //aktualizacja sktyptów bez tworzenia bazy danych 
                if(wersjaWBazie <= wersja || wymuszenieAktualizacji == 1)
                {
                    query = "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME like 'films' and CONSTRAINT_NAME like '%Cat%'";
                    var a = conn.ExecuteScalar<string>(query);
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
                //sqlList.Remove("V04.sql");
                
                foreach (string s in sqlList)
                {
                    FileInfo file = new FileInfo($"SQL/{s}");
                    //if(s == "V04.sql")
                    //{
                    //    query = "SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME like 'films' and CONSTRAINT_NAME like '%Cat%'";
                    //    string a = conn.ExecuteScalar<string>(query);
                    //    string query1 = $"ALTER TABLE dbo.films DROP CONSTRAINT {a}";
                    //    return query1;
                    //    var b = conn.ExecuteScalar(query1);
                    //}
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
        /// <param name="Title">Tytuł filmu</param>
        /// <param name="Content">OPis filmu</param>
        /// <param name="DataDodania">Data dodania dilmu </param>
        /// <param name="CatID">Kategoria do której należy film</param>
        /// <param name="Duration">Czas trwania filmu w minutach</param>
        /// <param name="Src">Link do obrazka </param>
        /// <param name="FilmID"><ID filmu domyslnie 0/param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieFilmu(string Title, string Content, DateTime DataDodania, int CatID, int Duration, string Film_Language, string Film_Production, string Film_Translation,  int FilmID = 0) 
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addFilm";
            var values = new
            {
                title = Title,
                content = Content,
                dataDodania = DataDodania,
                catID = CatID,
                duration = Duration,
                film_Language = Film_Language,
                film_Production = Film_Production,
                film_Translation = Film_Translation,
                id = FilmID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }

        /// <summary>
        /// method <c>DodanieOperatora</c> Umożliwia dodanie operatora lub edycję już istniejącego.
        /// </summary>
        /// <param name="Login">Login operatora</param>
        /// <param name="Typ">Typ operatora: 1 - kierownik; 2- klient</param>
        /// <param name="OperID">Id operatora</param>
        /// <param name="Password"> hasło operatora</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieOperatora(string Login, int Typ, int OperID = 0, string? Password = "")
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addOper";
            var values = new
            {
                login = Login,
                password = Password,
                typ = Typ,
                id = OperID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }

        /// <summary>
        /// method <c>DodanieSali</c> Umożliwia dodanie sali lub jej edycję
        /// </summary>
        /// <param name="NumberSR">Numer sali</param>
        /// <param name="ContentSR">opis sali</param>
        /// <param name="SRID">Id sali</param>
        /// <param name="Status">status sali: 0 - sala aktywna; 1 - sala nieaktywna</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieSali(int NumberSR, string ContentSR, int SRID = 0, int Status = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addSR";
            var values = new
            {
                nr = NumberSR,
                content = ContentSR,
                status = Status,
                id = SRID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }

        /// <summary>
        /// method <c>DodanieMiejsca</c> Umożliwia dodanie miejsca na sali lub jego edycję 
        /// </summary>
        /// <param name="SrID">ID Sali </param>
        /// <param name="NumberSeat">numer fotela</param>
        /// <param name="RowSeat">rząd foteli</param>
        /// <param name="SeatID">ID fotela</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieMiejsca(int SrID, int NumberSeat, int RowSeat, int SeatID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addSeat";
            var values = new
            {
                srid = SrID,
                nr = NumberSeat,
                row = RowSeat,
                id = SeatID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }

        /// <summary>
        /// method <c>DodanieKategorii</c> Umożliwia dodanie miejsca na sali lub jego edycję 
        /// </summary>
        /// <param name="Name">nazwa kategorii</param>
        /// <param name="CatId">ID kategorii</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieKategorii(string Name, int CatId = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "addCategory";
            var values = new { 
                name = Name
                , id = CatId
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieSeansu</c> Umożliwia dodanie seansu do wyświetlenia
        /// </summary>
        /// <param name="FilmID">ID filmu</param>
        /// <param name="SRID"> ID sali</param>
        /// <param name="DataEmisji">data rozpoczęcia seansu</param>
        /// <param name="DataKonca">data zakończenia seansu</param>
        /// <param name="SEID">ID seansu</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieSeansu(int FilmID, int SRID, DateTime DataEmisji, DateTime DataKonca, int SEID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "addSeance";
            var values = new
            {
                filmID = FilmID,
                srID = SRID,
                dataEmisji = DataEmisji,
                datakonca = DataKonca,
                id = SEID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// method <c>DodanieBiletu</c> Umożliwia dodanie biletu lub jego edycję
        /// </summary>
        /// <param name="OperId">ID operatora</param>
        /// <param name="SeatId">ID fotela</param>
        /// <param name="SeID">Id seansu</param>
        /// <param name="Type">typ biletu</param>
        /// <param name="DataZakupu">data zakupu</param>
        /// <param name="Code">kod promocyjny</param>
        /// <param name="StatusB">0 - rezerwacja; 1 - wykupiony; 2 - anulowany</param>
        /// <param name="BookID">id biletu</param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieBiletu(int OperId, int SeatId, int SeID, int Type, DateTime DataZakupu, int StatusB = 0, int Code = 0, int BookID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "addBooking";
            var values = new
            {
                operID = OperId,
                seatID = SeatId,
                seID = SeID,
                type = Type,
                dataZakupu = DataZakupu,
                code = Code,
                status = StatusB,
                id = BookID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
             
        public string WskazanieSciezkiDoObrazka()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return "";
        }

        public string DodanieObrazka(string Src, int FilmID, int PicID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addPicture";
            var values = new
            {
                id = PicID,
                filmID = FilmID,
                src = Src,
                            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }
       
        public string DodanieKategoriiDoFilmu(int CatID, int FilmID)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            var procedure = "dbo.addCategoryToFilm";
            var values = new
            {
                filmID = FilmID,
                catID = CatID
            };
            try
            {
                var results = conn.ExecuteScalar<string>(procedure, values, commandType: CommandType.StoredProcedure);
                return results;
            }
            catch (Exception ex)
            {
                return ex.Message;
            };
        }
    
    }
}
