using kino;
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
        public int Oper_ID { get; set; }
        public string? Oper_Login { get; set; }
        public int Oper_Type { get; set; }
        public string? Oper_Password = null;
        static kinoDB baza = new kinoDB(true);
        public Operator() { }
        public Operator(int id)
        {
            this.Oper_ID = id;
            var a = baza.GetOperators(id);
            if (a != null)
            {
                this.Oper_Login = a.Oper_Login;
                this.Oper_Type = a.Oper_Type;
                this.Oper_Password = a.Oper_Password;
            }
        }
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

        public bool logowanie(string username, string password)
        {
            var a = baza.GetOperators(username);

            if (a != null && encryptionPass(password) == a.Oper_Password)
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
            var a = baza.GetOperators(login);

            string pass = encryptionPass(password);
            var response = baza.DodanieOperatora(login, typ, 0, pass);
            return response;

        }
       
        public string modyfikacjaOperatora(int id, string? login = null, string? password = null, int typ = -1)
        {
            var a = baza.GetOperators(id);
            if (a != null)
            {
                string? opLogin = login == null ? a.Oper_Login : login;
                int opTyp = typ == -1 ? a.Oper_Type : typ;
                string? opPassword = password == null ? a.Oper_Password : encryptionPass(password);
                return baza.DodanieOperatora(opLogin, opTyp, id, opPassword);
            }
            else
            {
                return "Operator nie istnieje";
            }
        }
        
        public (int, int) modyfikacjaOperatora(Operator op)
        {
            int opTyp = 1;
            string? opLogin = op.Oper_Login;
            if (op.Oper_ID != 1)
            {
                opTyp = op.Oper_Type;
            }
            string? opPassword = encryptionPass(op.Oper_Password);
            return baza.dodajOperatora(op);
        }
        
        public static string usun(int id)
        {
            if (id > 1 && id != Program.zalogowanyOperator.Oper_ID)
            {
                baza.usunOperatora(id);
                return "poprawnie usunięto";
            }
            else
            {
                return "Nie można usunąć super Admina";
            }
        }
    }
}
    