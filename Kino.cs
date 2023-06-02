using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Dapper;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Projekt_kino;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kino
{
    internal class kinoDB
    {
        // TODO: poprawić w procedurach zwracana komunikaty -> dodać convert albo ogarnąć to z poziomu c#
        private decimal wersja = 1.0m;

        private string? connectionString;
        public string? serwer { get; set; }
        public string? baza_danych { get; set; }
        public string? login { get; set; }
        public string? haslo { get; set; }
        public bool loginmethod { get; set; }
        public SqlConnection conn;

        public kinoDB() {
            if(connectionString == null)
            {
                conn = new SqlConnection(connectionString);
            }
        }
        
        public kinoDB(bool polaczenie)
        {
            if (polaczenie)
            {
                PolaczenieDoBazyZRejestru();
                conn = new SqlConnection(connectionString);
            }
        }

        public bool PolaczenieDoBazyZRejestru()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Kino");
            if (key != null) {
                string server = key.GetValue("server").ToString();
                string loginMethod = key.GetValue("loginMethod").ToString();
                string database = key.GetValue("database").ToString();
                string login = key.GetValue("login").ToString();
                string passowrd = key.GetValue("passowrd").ToString();
                connectionString = loginMethod == "True" ? $"Data Source={server}; Database={database}; Integrated Security=SSPI;" : $"Data Source={server}; Initial Catalog = {database}; User ID={login}; Password={passowrd}";
                this.serwer = server;
                this.baza_danych = database;
                this.login = login;
                this.haslo = passowrd;
                this.loginmethod = loginMethod == "True" ? true : false;
                conn = new SqlConnection(connectionString);
                key.Close();
                return true;
            }
            key.Close();
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
        public bool ConnectionString(string server, bool loginMethod, string database, string login = "", string passowrd = "")
        {
            string conString = loginMethod == true ? $"Data Source={server}; Database={database}; Integrated Security=SSPI;" : $"Data Source={server}; Initial Catalog = {database}; User ID={login}; Password={passowrd}";
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
                    this.serwer = server;
                    this.baza_danych = database;
                    this.login = login;
                    this.haslo = passowrd;
                    this.loginmethod =loginMethod;
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
                "V07.sql",
                "V08.sql",
                "V09.sql",
                "V10.sql",
            };
            //sprawdzenie istnienia bazy konfiguracujnej
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Config'";
            var tableList = conn.ExecuteScalar<string>(query);
            if (tableList == "config")
            {
                //sprawdzenie wersji w bazie 
                query = "SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 1";
                decimal wersjaWBazie = (decimal)conn.ExecuteScalar<decimal>(query) / 10;
                if(wersjaWBazie >= 0.4m)
                {
                    sqlList.Remove("V04.sql");
                }
                if (wersjaWBazie >= 0.7m)
                {
                    sqlList.Remove("V07.sql");
                }
                if (wersjaWBazie >= 0.8m)
                {
                    sqlList.Remove("V08.sql");
                }
                if (wersjaWBazie >= 0.9m)
                {
                    sqlList.Remove("V09.sql");
                }
                if (wersjaWBazie >= 1.0m)
                {
                    sqlList.Remove("V10.sql");
                }
                //aktualizacja sktyptów bez tworzenia bazy danych 
                if (wersjaWBazie <= wersja || wymuszenieAktualizacji == 1)
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
        /// <param name="DataDodania">Data dodania filmu </param>
        /// <param name="CatID">Kategoria do której należy film</param>
        /// <param name="Duration">Czas trwania filmu w minutach</param>
        /// <param name="Src">Link do obrazka </param>
        /// <param name="FilmID"><ID filmu domyslnie 0/param>
        /// <returns>Zwracany tekst z błędem lub komunikatem o poprawnym dodaniu</returns>
        public string DodanieFilmu(string Title, string Content, DateTime? DataDodania, int Duration, string Film_Language, string Film_Production, string Film_Translation,  int FilmID = 0) 
        {
            var procedure = "dbo.addFilm";
            var values = new
            {
                title = Title,
                content = Content,
                dataDodania = DataDodania,
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
            var procedure = "dbo.addOper";
            var values = new
            {
                OpLogin = Login,
                OpPassword = Password,
                OpTyp = Typ,
                OpId = OperID
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
        
        public Operator GetOperators(string login)
        {
            string query = $"SELECT TOP 1 * FROM dbo.operator WHERE Oper_Login = '{login}'";
            Operator a;
            try
            {
                a = conn.QuerySingle<Operator>(query);
            }
            catch
            {
                a = null;
            }
            return a;
        }
        
        public Operator GetOperators(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = $"SELECT TOP 1 * FROM dbo.operator WHERE Oper_ID = {id}";
            Operator a;
            try
            {
                a = conn.QuerySingle<Operator>(query);
            }
            catch
            {
                a = null;
            }
            return a;
        }
        
        public Filmy GetFilmy(int id, bool metoda)
        {
            //true -> po id filmu
            //false -> po id seansu
            string query;
            if (metoda)
            {
                query = $"SELECT TOP 1 * FROM dbo.films WHERE Film_ID = {id}";
            }
            else
            {
                query = $"SELECT TOP 1 films.* FROM dbo.films JOIN dbo.seance ON SE_FilmID = Film_ID WHERE SE_ID = {id}";
            }
            Filmy a;
            try
            {
                a = conn.QuerySingle<Filmy>(query);
            }
            catch
            {
                a = null;
            }
            return a;
        }

        public List<seanse> getSeanceOnFilmAndDay(DateTime data, int filmID)
        {
            string query = $"SELECT * FROM dbo.seance WHERE SE_DataEmisji >= '{data.ToString("yyyy-MM-dd HH:mm")}' AND SE_DataEmisji < '{data.AddDays(1).ToString("yyyy-MM-dd")}' AND SE_FilmID = {filmID}";
            List<seanse> a;
            try
            {
                a = conn.Query<seanse>(query).ToList();
            }
            catch
            {
                a = null;
            }
            return a;
        }

        public List<(int, string)> getCategory(int id)
        {
            string query = $"SELECT Cat_ID, Cat_Name FROM dbo.category JOIN dbo.cat_film ON Cat_ID = CF_CatID WHERE CF_FilmID = {id}";
            List<(int, string)> a;
            try
            {
                a = conn.Query<(int, string)>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public List<Filmy> getFilmList(DateTime data)
        {
            
            string query = $"SELECT DISTINCT films.* FROM dbo.films JOIN dbo.seance ON Film_ID = SE_FilmID WHERE SE_DataEmisji >= '{data.ToString("yyyy-MM-dd HH:mm")}' AND SE_DataEmisji < '{data.AddDays(1).ToString("yyyy-MM-dd")}'";
            List<Filmy> a;
            try
            {
                a = conn.Query<Filmy>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public List<(int, string)> getPic(int idFIlm)
        {
            string query = $"SELECT Pic_ID, Pic_Src FROM dbo.picture WHERE pic_FilmId = {idFIlm} ORDER BY Pic_Sequence";
            List<(int, string)> a;
            try
            {
                a = conn.Query<(int, string)>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public List<line_up> GetLine_Ups(int idFIlm, int status)
        {
            string query = $"SELECT LU_ID, LU_Name, LU_Surname, LU_Country, LF_Status FROM dbo.line_up JOIN dbo.lu_film ON LU_ID = LF_LUID WHERE LF_FilmID = {idFIlm} AND LF_Status = {status}";
            List<line_up> a;
            try
            {
                a = conn.Query<line_up>(query).ToList();
            }
            catch { a = null; }
            return a;
        }
        
        public List<seanse> getOneSeanse(int seanceID)
        {
            string query = $"SELECT * FROM dbo.seance WHERE SE_ID = {seanceID}";
            List<seanse> a;
            try
            {
                a = conn.Query<seanse>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public string dodanieFilmu2(Filmy film)
        {
            string query;
            if (film.Film_ID == 0)
            {
                #region sprawdzenie warunków
                //istnienie filmu w bazie
                query = $"SELECT Film_ID FROM dbo.films WHERE Film_Title LIKE '{film.Film_Title}'";
                int a;
                try
                {
                    a = conn.QueryFirst<int>(query);
                }
                catch
                {
                    a = 0;
                }
                if (a != 0) { return "Film o takim tytule istenije"; }
                //istnienie kategorii w bazie
                if (film.Film_Cateogry != null)
                {
                    foreach (var categoria in film.Film_Cateogry)
                    {
                        if(!zapytanie($"SELECT TOP 1 Cat_ID FROM dbo.category WHERE Cat_Name like '{categoria}'")) { return $"Podana kategoria nie istanieje w bazie {categoria}"; }
                    }
                }
                //istnienie aktorów w bazie
                if(film.line_up != null)
                {
                    foreach(var aktor in film.line_up)
                    {
                        if(!zapytanie($"SELECT TOP 1 LU_ID FROM dbo.line_up WHERE Cat_Name like '{aktor}'")) { return $"Podany aktor nie istanieje w bazie {aktor}"; }
                    }
                }
                #endregion
                #region dodanie filmu
                query = @$"INSERT INTO dbo.films (
                            Film_Title, 
                            Film_Content, 
                            Film_Duration,
                            Film_DataDodania,
                            Film_Language, 
                            Film_Translation,
                            Film_Production 
                          ) 
                          OUTPUT INSERTED.Film_ID
                          VALUES (
                            '{film.Film_Title}',
                            '{film.Film_Content}', 
                            {film.Film_Duration}, 
                            '{DateTime.Now}', 
                            '{film.Film_Language}',
                            '{film.Film_Translation}',
                            '{film.Film_Production}'
                          )";
                try
                {
                    film.Film_ID = conn.QuerySingle<int>(query);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                #endregion
                #region dodanie kategorii
                if (film.Film_Cateogry != null)
                {
                    foreach (var categoria in film.Film_Cateogry)
                    {
                        query = $"SELECT TOP 1 Cat_ID FROM dbo.category WHERE Cat_Name like '{categoria}'";
                        int catId;
                        try
                        {
                           catId = conn.QueryFirst<int>(query);
                        }
                        catch
                        {
                            return $"Podana kategoria nie istanieje w bazie {categoria}";
                        }
                        query = $"INSERT INTO dbo.cat_film (CF_CatID, CF_FilmID) VALUES ({catId}, {film.Film_ID})";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
                }
                #endregion
                #region dodanie aktorów
                if (film.line_up != null)
                {
                    foreach (var aktor in film.line_up)
                    {
                        query = $"SELECT TOP 1 LU_ID FROM dbo.line_up WHERE LU_ID = {aktor.LU_ID}";
                        int luID;
                        try
                        {
                            luID = conn.QueryFirst<int>(query);
                        }
                        catch
                        {
                            return $"Podany aktor nie istanieje w bazie {aktor}";
                        }
                        query = $"INSERT INTO sbo.lu_film (LF_FilmID, LF_LUID, LF_Status) VALUES ({film.Film_ID}, {luID}, {aktor.LF_Status})";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                    }
                }
                #endregion
                #region dodanie obrazka
                if(film.Pic_Src != null)
                {
                    int sequence = 0;
                    foreach (var obrazek in film.Pic_Src)
                    {
                        query = $"INSERT INTO dbo.picture (Pic_FilmID, Pic_Src, Pic_Sequence) VALUES ({film.Film_ID}, '{obrazek}', {sequence})";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch (Exception ex)
                        {
                            return ex.Message;
                        }
                        sequence++;
                    }
                }
                #endregion

                #region dodanie seansów
                dodanieSeansu2(film);
                #endregion
            }
            else
            {
                // TODO: dokończyć pracę nad modyfikacją filmów przy powiązaniach 1:n n:n
                #region sprawdzenie warunków
                query = $"SELECT * FROM dbo.films WHERE Film_ID = {film.Film_ID} AND Film_Title = '{film.Film_Title}'";
                Filmy tempFilm;
                try
                {
                    tempFilm = conn.QueryFirst<Filmy>(query);
                }
                catch
                {
                    return "Nie ma takiego filmu w bazie";
                }
                #endregion
                
                query = $@"UPDATE dbo.films SET 
                            Film_Title = '{film.Film_Title}', 
                            Film_Content = '{film.Film_Content}', 
                            Film_Duration = {film.Film_Duration},  
                            Film_DataModyfikacji = '{DateTime.Now}',
                            Film_Language = '{film.Film_Language}', 
                            Film_Production = '{film.Film_Production}', 
                            Film_Translation =  '{film.Film_Translation}'
                            WHERE Film_ID = {film.Film_ID}";
                try
                {
                    conn.Execute(query);
                    return $"zmodyfikowano film: {film.Film_ID}";
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
           


            }
            return "a";
        }
    
        public string dodanieSeansu2(Filmy film)
        {
            if(film.seanses != null)
            {
                string query;
                if(!zapytanie($"SELECT Film_ID FROM dbo.films WHERE Film_ID = {film.Film_ID}")) { return "Film nie istnieje w bazie"; }
                foreach (var seans in film.seanses) 
                {
                    if (seans.SE_ID == 0)
                    {
                        if (!zapytanie($"SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = {seans.SE_SRID}")) { return "Sala nie istnieje w bazie"; }
                        if (zapytanie($"SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = {seans.SE_SRID} AND ('{seans.SE_DataKonca}' > SE_DataEmisji AND  SE_DataKonca > '{seans.SE_DataEmisji}')")) { return "w podanym czasie istnieje inny seans"; }
                        query = $"INSERT INTO dbo.seance (SE_DataEmisji, SE_FilmID, SE_SRID, SE_DataKonca) VALUES ('{seans.SE_DataEmisji}', {film.Film_ID}, {seans.SE_SRID}, '{seans.SE_DataKonca}')";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch(Exception ex) { return ex.Message;}
                    }
                    else
                    {
                        if(!zapytanie($"SELECT SE_ID FROM dbo.seance WHERE SE_ID = {seans.SE_ID}")) { return "brak seansu w bazie"; }
                        query = $"UPDATE dbo.seance SET SE_FilmID = {film.Film_ID}, SE_DataEmisji = '{seans.SE_DataEmisji}', SE_SRID = {seans.SE_SRID}, SE_DataKonca = '{seans.SE_DataKonca}' WHERE SE_ID = {seans.SE_ID}";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch (Exception ex) { return ex.Message; }
                    }
                }
                return "dodano wszystkie wpisy";
            }
            else
            {
                return "Brak sensów do dodania";
            }
        }

        protected bool zapytanie(string query)
        {
            try
            {
                conn.QueryFirst<int>(query);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        protected int zapytanieINT(string query)
        {
            try
            {
                
                return conn.QueryFirst<int>(query);
            }
            catch
            {
                return -1;
            }
        }

        public void aktualizacjaSeansów()
        {
            string query = "SELECT SE_ID, SE_DataEmisji, SE_DataKonca FROM dbo.seance";
            var a = conn.Query<(int, DateTime, DateTime)>(query).ToList();
            foreach(var b in a)
            {
                var c = DateTime.Now.Day - b.Item2.Day + 1;
                DateTime DE = b.Item2.AddDays(c);
                DateTime DK = b.Item3.AddDays(c);
                query = $"Update dbo.seance SET SE_DataEmisji = '{DE.ToString("yyyy-MM-dd HH:mm")}', SE_DataKonca = '{DK.ToString("yyyy-MM-dd HH:mm")}' WHERE SE_ID = {b.Item1}";
                zapytanie(query);
            }
        }
        
        public miejsce pobranieMiejsca(int idMiejsca)
        {
            string query = $"SELECT TOP 1 * FROM dbo.seats WHERE Seat_ID = {idMiejsca}";
            miejsce a;
            try
            {
                a = conn.QueryFirst<miejsce>(query);
            }
            catch
            {
                a = null;
            }
            return a;
        }
        
        public List<miejsce> pobranieMiejsc(int SalaId, int SE_ID = 0)
        {
            string query = $"SELECT Seat_ID, Seat_Nr, Seat_Row FROM dbo.seats WHERE Seat_SRID = {SalaId}";
            List<miejsce> a;
            try
            {
                a = conn.Query<miejsce>(query).ToList();
            }
            catch { a = null; }
            if(a != null && SE_ID != 0)
            {
                foreach(var mie in a)
                {
                    query = $"SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = {mie.Seat_ID} AND Book_SeID = {SE_ID}";
                    int stat;
                    try
                    {
                        stat = conn.QueryFirst<int> (query);

                    }
                    catch { stat = 0; }
                    if (stat > 0)
                    {
                        mie.status = true;
                    }
                    else
                    {
                        mie.status = false;
                    }
                }
            }
            return a;
        }

        public sala pobranieSali(int srId)
        {
            string query = $"SELECT TOP 1 * FROM dbo.screeningRoom WHERE SR_ID = {srId}";
            sala a;
            try
            {
                a = conn.QueryFirst<sala>(query);
            }
            catch
            {
                a = null;
            }
            return a;
        }
        
        public void ustawienieCen()
        {
            string query = "SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 2";
            var a = conn.QueryFirst<string> (query);
            Program.cenaNormalna = decimal.Parse(a);
            query = "SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 3";
            a = conn.QueryFirst<string>(query);
            Program.cenaUlgowa = decimal.Parse(a);
        }

        public List<(int, string, int)> pobranieOper()
        {
            string query = "SELECT Oper_ID, Oper_Login, Oper_Type FROM dbo.operator";
            List<(int, string, int)> a;
            try
            {
               a = conn.Query<(int, string, int)>(query).ToList();
            }
            catch {  a = null; }
            return a;
        }

        public void usunOperatora(int id)
        {
            string query = $"DELETE FROM dbo.operator WHERE Oper_ID = {id}";
            try
            {
                conn.Execute(query);
            }
            catch { }
        }

        public (int, int) dodajOperatora(Operator op)
        {
            string query = $"SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = '{op.Oper_Login}'";
            if(zapytanieINT(query) > -1) { return (1, -1); }
            int kom, a;
            
            if(op.Oper_ID > 0)
            {
                query = $"SELECT Oper_ID FROM dbo.operator WHERE Oper_ID = {op.Oper_ID}";
                if(zapytanieINT(query) == -1) { return (2, -1); }
                query = $"UPDATE dbo.operator SET Oper_Login = '{op.Oper_Login}', Oper_Password = '{op.Oper_Password}', Oper_Type = {op.Oper_Type} WHERE Oper_ID = {op.Oper_ID}";
                kom = 3;
                try
                {
                    conn.Execute(query);
                    return (kom, op.Oper_ID);
                }
                catch { return (4, -1); }
            }
            else
            {
                query = $"INSERT INTO dbo.operator (Oper_Login, Oper_Password, Oper_Type) OUTPUT INSERTED.Oper_ID VALUES ('{op.Oper_Login}', '{op.Oper_Password}', {op.Oper_Type})";
                kom = 5;
                try
                {
                    a = conn.QuerySingle<int>(query);
                    return (kom, a);
                }
                catch { return (4, -1); }
            }
            
        }

        public List<(int, string)> pobranieListyFilmow()
        {
            string query = "SELECT Film_ID, Film_Title FROM dbo.films";
            List<(int, string)> a;
            try
            {
                a = conn.Query<(int, string)>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public List<(int, string)> pobranieListySal()
        {
            string query = "SELECT SR_ID, SR_Nr FROM dbo.screeningRoom";
            List<(int, string)> a;
            try
            {
                a = conn.Query<(int, string)>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public List<(int, string)> pobranieListyKategori()
        {
            string query = "SELECT * FROM dbo.category";
            List<(int, string)> a;
            try
            {
                a = conn.Query<(int, string)>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public bool usunKategorie(int KatId)
        {
            string query = $"SELECT Cat_ID FROM dbo.category WHERE Cat_ID = {KatId}";
            int a;
            try
            {
                a = conn.QueryFirst<int>(query);
                if(a != 0)
                {
                    query = $"SELECT count(CF_ID) FROM dbo.cat_film WHERE CF_CatID = {KatId}";
                    try
                    {
                        a = conn.QueryFirst<int>(query);
                        if(a == 0)
                        {
                            query = $"DELETE dbo.category WHERE Cat_ID = {KatId}";
                            conn.Execute(query);
                            return true;
                        }
                        return false;
                    }
                    catch { return false; }
                }
            }
            catch { return false; }
            return false;
        }

        public (int, string) pobranieKategori(int Katid)
        {
            string query = $"SELECT * FROM dbo.category WHERE Cat_ID = {Katid}";
            (int, string) a;
            try
            {
                a = conn.QueryFirst<(int, string)>(query);
            }
            catch { a = (-1, null); }
            return a;
        }

        public (int, int) dodanieKategorii(string kat, int id)
        {
            string query = $"SELECT Cat_ID FROM dbo.category WHERE Cat_Name = '{kat}'";
            if(zapytanieINT(query) > 0) { return (6, id); }
            (int, int) kom;
            if(id > 0)
            {
                query = $"SELECT Cat_ID FROM dbo.category WHERE Cat_ID = {id}";
                if(zapytanieINT(query) == 0) { return (7, id); }
                query = $"UPDATE dbo.category SET Cat_Name = '{kat}' WHERE Cat_ID = {id}";
                try
                {
                    conn.Execute(query);
                    return (8, id); ;
                }
                catch { return (4, id); }
            }
            else
            {
                query = $"INSERT INTO dbo.category (Cat_Name) OUTPUT INSERTED.Cat_ID VALUES ('{kat}')";
                try
                {
                    int a = conn.QuerySingle<int>(query);
                    return (9, a); ;
                }
                catch { return (4, id); }
            }
           
        }
        
        public bool aktualizacjaKategorii(List<int> listaKategori, int filmID)
        {
            string query = $"DELETE dbo.cat_film WHERE CF_FilmID = {filmID}";
            try
            {
                conn.Execute(query);
            }
            catch { return false; }

            foreach(int i in listaKategori)
            {
                query = $"INSERT INTO dbo.cat_film (CF_CatID, CF_FilmID) VALUES ({i}, {filmID})";
                zapytanie(query);
            }
            return true;
        }
        
        public bool usunSale(int SalId)
        {
            // sprawdzenie czy sala nie jest wykorzystana do seansu
            string query = $"SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_SRID = {SalId}";
            int a;
            try
            {
                a = conn.QueryFirst<int>(query);
                if(a != 0) { return false; }
                // pobranie listy miejsc
                query = $"SELECT Seat_ID FROM dbo.Seats WHERE Seat_SRID = {SalId}";
                List<int> listaMiejsc;
                try
                {
                    listaMiejsc = conn.Query<int>(query).ToList();
                }
                catch { return false; }
                // sprawdzenie czy miejsce nie było wykupione
                foreach(int miejsce in listaMiejsc)
                {
                    query = $"SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = {miejsce}";
                    try
                    {
                        a = conn.QueryFirst<int>(query);
                    }
                    catch { return false; }
                    if(a != 0) { return false; };
                }

                query = $"DELETE dbo.seats WHERE Seat_SRID = {SalId}";
                conn.Execute(query);
                query = $"DELETE dbo.screeningRoom WHERE SR_ID = {SalId}";
                conn.Execute(query);

            }
            catch { return false; }
            return false;
        }
    
        public bool modyfikacjaSali(sala sal, bool zmianaMiejsc)
        {
            // czy numer sali jest już wykorzytsywany
            string query = $"SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = {sal.SR_Nr}";
            int a;
            try
            {
                if (sal.SR_ID > 0)
                {
                    a = conn.QueryFirst<int>(query);
                    if (a == 0) { return false; }
                    // czy sala nie istnieje na seansie
                    query = $"SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_SRID = {sal.SR_ID}";
                    if (zapytanieINT(query) > -1) { return false; }

                    if (zmianaMiejsc)
                    {
                        //czy miejsce nie jest już wykupione
                        foreach (miejsce tempmiejsce in sal.listaMiejsc)
                        {
                            query = $"SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = {tempmiejsce.Seat_ID}";
                            if (zapytanieINT(query) != 0) { return false; }
                        }
                        // czy sala mmiała już jakiejś miejsca
                        query = $"SELECT TOP 1 Seat_ID FROM dbo.seats WHERE Seat_SRID = {sal.SR_ID}";
                        if (zapytanieINT(query) != 0) {
                            // usuniecie miejsc przypisanych do sali
                            query = $"DELETE dbo.seats WHERE Seat_SRID = {sal.SR_ID}";
                            if (!zapytanie(query)) { return false; }
                        }
                        //dodanie miejsc do sali
                        foreach (miejsce tempmiejsce in sal.listaMiejsc)
                        {
                            query = $"INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES ({sal.SR_ID}, {tempmiejsce.Seat_Nr}, {tempmiejsce.Seat_Row})";
                            try
                            {
                                conn.Execute(query);
                            }
                            catch { return false; }
                        }
                    }
                    // aktualizacja sali
                    query = $"UPDATE dbo.screeningRoom SET SR_Content = '{sal.SR_Content}', SR_Nr = {sal.SR_Nr}, SR_Status = 0, SR_MaxRowMiejsca = {sal.SR_maxRowMiejsca}, SR_MaxNrMiejsca = {sal.SR_maxNrMiejsca} WHERE SR_ID = {sal.SR_ID}";
                    if (zapytanie(query)) { return true; }
                }
                else
                {
                    // czy numer sali nie jest juz wykorzystywany
                    query = $"SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = {sal.SR_Nr}";
                    if (zapytanieINT(query) > -1) { return false; }
                    // dodanie sali
                    query = $"INSERT INTO dbo.screeningRoom (SR_Nr, SR_Content, SR_Status, SR_MaxRowMiejsca, SR_MaxNrMiejsca) OUTPUT Inserted.SR_ID VALUES ({sal.SR_Nr}, '{sal.SR_Content}', 0, {sal.SR_maxRowMiejsca}, {sal.SR_maxNrMiejsca})";
                    try
                    {
                        sal.SR_ID = conn.QuerySingle<int>(query);
                    }
                    catch {  return false; }
                    if(sal.SR_ID == 0) { return false; }
                    // czy sala mmiała już jakiejś miejsca
                    query = $"SELECT TOP 1 Seat_ID FROM dbo.seats WHERE Seat_SRID = {sal.SR_ID}";
                    if (zapytanieINT(query) > -1)
                    {
                        // usuniecie miejsc przypisanych do sali
                        query = $"DELETE dbo.seats WHERE Seat_SRID = {sal.SR_ID}";
                        if (!zapytanie(query)) { return false; }
                    }
                    //dodanie miejsc do sali
                    foreach (miejsce tempmiejsce in sal.listaMiejsc)
                    {
                        query = $"INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES ({sal.SR_ID}, {tempmiejsce.Seat_Nr}, {tempmiejsce.Seat_Row})";
                        try
                        {
                            conn.Execute(query);
                        }
                        catch { return false; }
                    }

                }
            }
            catch { return false; }
            return true;
        }

        public bool dodajZdjecie(string src,int sequence, int filmID, int pic_id = -1)
        {
            string query;
            if (sequence == 0)
            {
                // sprawdzenie czy film nie ma już zdjęcia głównego 
                query = $"SELECT TOP 1 Pic_ID FROM dbo.picture WHERE Pic_FIlmID = {filmID} AND Pic_Sequence = {sequence}";
                if (zapytanieINT(query) > 0) { return false; }
            }
            if (pic_id == -1)
            {
                // dodanie zdjecia
                query = $"INSERT INTO dbo.picture(Pic_Src, Pic_Sequence, Pic_FilmID) VALUES ('{src}', {sequence}, {filmID})";
                try
                {
                    conn.Execute(query);
                    return true;
                }
                catch { return false; }
            }
            else{
                query = $"UPDATE dbo.picture SET Pic_Sequence = {sequence}, Pic_Src = '{src}' WHERE Pic_ID = {pic_id}";
                zapytanie(query);
                return true;
            }
        }
    
        public (string, int) pobranieZdjecia(int picId)
        {
            string query = $"SELECT Pic_Src, Pic_Sequence FROM dbo.picture WHERE Pic_ID = {picId}";
            (string, int) a;
            try
            {
                a = conn.QueryFirst<(string, int)>(query);
            }
            catch { a = (null, -1); }
            return a;
        }
   
        public bool usunZdjecie(int picId)
        {
            string query = $"DELETE dbo.picture WHERE Pic_ID = {picId}";
            try
            {
                conn.Execute(query);
                return true;
            }
            catch { return false; }
        }
    
        public List<seanse> pobranieListySeansowDoFIlmu(int filmId)
        {
            string query = $"SELECT * FROM dbo.seance WHERE SE_FilmID = {filmId}";
            List<seanse> a;
            try
            {
                a = conn.Query<seanse>(query).ToList();
            }
            catch { a = null; }
            return a;
        }
    
        public int getIdSali(int nr)
        {
            string query = $"SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = {nr}";
            return zapytanieINT(query);
        }
    
        public bool dodajSeans(seanse seans)
        {
            return false; 
            //TODO: zrobić
        }

        public bool usunSeans(int seansId)
        {
            return false;
            //TODO: zrobić
        }
        
        public List<line_up> pobranieListyAktorow(int filmId)
        {
            string query = $"SELECT LU_ID, LU_Name, LU_Surname, LU_Country, LF_Status FROM dbo.line_up JOIN dbo.lu_film ON LF_LUID = LU_ID WHERE LF_FilmID = {filmId}";
            List<line_up> a;
            try
            {
                a = conn.Query<line_up>(query).ToList();
            }
            catch { a = null; }
            return a;
        }

        public bool usunAktora(int aktorId) {
            return false;
        }

        public bool zapiszFilm(Filmy film)
        {
            return false;
        }
    }
}
