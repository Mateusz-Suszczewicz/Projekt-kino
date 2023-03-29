using Microsoft.VisualBasic.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;



namespace kino
{
    internal class kinoDB
    {
        // WERSJA 0.1
        // TODO: Przebudować metody na mechanizm Dappera
        private string? connectionString;
        
        /// <summary>
        /// method <c>ConnectionString</c> Ustawienie linku do połączenie do bazy danych 
        /// </summary>
        /// <param name="server">Adres serwera do którego chcemy się połączyć</param>
        /// <param name="loginMethod">Metoda logowania: 1 - Logowanie zintegrowane 2 - poprzez autoryzację SQL</param>
        /// <param name="database">Baza danych do której się chcemy podpiąć</param>
        /// <param name="login">Login użytkownika bazy danych</param>
        /// <param name="passowrd">Hasło użytkownika bazy danych</param>
        /// <returns>Zwraca TRUE jesli połączenie się powiodło i FALSE jeśli się nie powiodło</returns>
        public bool ConnectionString(string server, int loginMethod, string database, string? login = null, string? passowrd = null)
        {
            SqlConnection conn;
            string conString = loginMethod == 1 ? $"Data Source={server}; Database={database}; Integrated Security=SSPI;" : $"Data Source={server}; Initial Catalog = {database}; User ID={login}; Password={passowrd}";
            conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                conn.Close();
                connectionString = conString;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// method <c>CreateTable</c> Tworzy tabele w bazie danych zalecane jednokrotne uruchomienie
        /// </summary>
        public void CreateTable() // TODO: Przygotować mechanizm pod sprawdzanie tabel i dodawanie nowych 
        {
            FileInfo file = new FileInfo("create.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(script, conn);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            catch
            {
                //return 0;
            }
            finally { conn.Close(); }
        }

        /// <summary>
        /// method <c>InstallScipt</c> Instalacja skryptów -> w trakcie budowy
        /// </summary>
        private void InstallScipt() // TODO: do podpięcia skrypty i przygototowanie mechanizmu do weryfikcaji wersji 
        {

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
            if(filmID != 0)
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
        public string DodanieOperatora(string Login,  int Typ, int operID = 0, string? Haslo = "")
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addOper", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Haslo;
            cmd.Parameters.Add("@typ", SqlDbType.Int).Value = Typ;
            if(operID != 0)
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
            cmd.CommandType= CommandType.StoredProcedure;
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
      
        //MIEJSCE
        public string DodanieMiejsca(int srID, int numberSeat, int rowSeat, int SeatID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addSeat", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@srid", SqlDbType.Int).Value = srID;
            cmd.Parameters.Add("@nr", SqlDbType.VarChar).Value = numberSeat;
            cmd.Parameters.Add("@row", SqlDbType.Int).Value = rowSeat;
            if(SeatID != 0)
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
    
        //KATEGORIA
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

        //SEANSE
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
        
        //BOOKING
        public string DodanieBiletu(int operID, int seatID, int SeID, int type, DateTime dataZakupu, int CodeId = 0, int bookID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addBooking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OperId", SqlDbType.Int).Value = operID;
            cmd.Parameters.Add("@SeatId", SqlDbType.Int).Value = seatID;
            cmd.Parameters.Add("@SeId", SqlDbType.Int).Value = SeID;
            cmd.Parameters.Add("@CodeId", SqlDbType.Int).Value = CodeId;
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
}
