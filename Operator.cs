﻿using kino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Projekt_kino
{
    public class Operator
    {
        private int Oper_ID;
        private string? Oper_Login;
        private string? Oper_Password = null;
        private int Oper_Type;

        public string GetOperLogin() { return Oper_Login; }
        public int GetOperType() { return Oper_Type; }
        public int GetOperId() { return Oper_ID; }

        private string encryptionPass(string password)
        {
            string a = "";
            foreach (char c in password)
            {
                int b = c + 1;
                a += (char)b;
            }
            return a;
        }
        
        private string decryptionPass(string password)
        {
            string a = "";
            foreach (char c in password)
            {
                int b = c - 1;
                a += (char)b;
            }
            return a;
        }

        public bool logowanie(string username, string password)
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            var a = baza.GetOperators(username);

            if(a != null && encryptionPass(password) == a.Oper_Password)
            {
                Oper_ID = a.Oper_ID;
                Oper_Login = a.Oper_Login;
                Oper_Type = a.Oper_Type;
                return true;
            }
            return false;
        }

        public string dodanienowegoOperatora(string login, string password, int typ)
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            var a = baza.GetOperators(login);
           
            string pass = encryptionPass(password);
            var response = baza.DodanieOperatora(login, typ, 0, pass);
            return response;
            
        }
        public string modyfikacjaOperatora(int id, string? login = null, string? password = null, int typ = -1) 
        {
            kinoDB baza = new kinoDB();
            baza.PolaczenieDoBazyZRejestru();
            var a = baza.GetOperators(id);
            if(a != null)
            {
                string? opLogin = login == null ? a.Oper_Login : login;
                int opTyp = typ == -1 ? a.Oper_Type : typ;
                string? opPassword = password == null ? a.Oper_Password :encryptionPass(password);
                return baza.DodanieOperatora(opLogin, opTyp, id, opPassword);
            }
            else
            {
                return "Operator nie istnieje";
            }
        }
    }
}
    