﻿using Microsoft.VisualBasic.Logging;
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

        public void CreateTable() // TODO: Do przemyślenia jak zrobić zeby można było to wywwołać za każdym razem i obsłużyć sytuację kiedy tabele juz powstały 
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

        public void InstallScipt() // TODO: do podpięcia skrypty 
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

        //FILM
        public string DodanieFilmu(string tytul, string opis, DateTime DataDodania, int sala, int category, int duration, string srcPicture, int filmID = 0)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("dbo.addFilm", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = tytul;
            cmd.Parameters.Add("@Content", SqlDbType.VarChar).Value = opis;
            cmd.Parameters.Add("@DataDodania", SqlDbType.DateTime).Value = DataDodania;
            cmd.Parameters.Add("@Sala", SqlDbType.Int).Value = sala;
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
        
        //OPERATOR
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
                
        //SALA
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
        
        
        

    }
}