using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace kino
{
    internal class kinoDB
    {

        private string? connectionString;

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

        public void CreateTable() // Do przemyślenia jak zrobić zeby można było to wywwołać za każdym razem i obsłużyć sytuację kiedy tabele juz powstały 
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

        public void InstallScipt()
        {

        }

        public SqlDataReader ShowFilms()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "SELECT * FROM dbo.FIlmListV";
            SqlCommand command = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

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

        public void DodanieFilmu(string tytul, string opis, DateTime dataEmisji, int sala, int category, int duration)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addFilm", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = tytul;
            cmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = opis;
            cmd.Parameters.Add("@DataEmisji", SqlDbType.DateTime).Value = dataEmisji;
            cmd.Parameters.Add("@Sala", SqlDbType.Int).Value = sala;
            cmd.Parameters.Add("@Category", SqlDbType.Int).Value = category;
            cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            conn.Open();
            cmd.ExecuteNonQuery();
            var result = returnParameter.Value;
            Console.WriteLine(result.ToString());
        }


    }
}
