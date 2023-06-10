using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodaniaOperatora : Form
    {
        Operator oper = new Operator();
        int id;
        public OknoDodaniaOperatora()
        {
            InitializeComponent();
        }
        public void ustawienieID(int id)
        {
            if (id > 0)
            {
                Operator oper1 = new Operator(id);
                textBoxhaslo.Text = oper1.Oper_Password;
                textBoxNazwa.Text = oper1.Oper_Login;
                checkBoxAdmin.Checked = oper1.Oper_Type == 0 ? true : false;
                oper.Oper_ID = id;
                oper.Oper_Password = oper1.Oper_Password;
                oper.Oper_Login = oper1.Oper_Login;
                oper.Oper_Type = oper1.Oper_Type;
            }
            else
            {
                this.id = id;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Operator oper2 = new Operator();
            if (oper.Oper_ID > 0)
            {
                oper2.Oper_ID = oper.Oper_ID;
            }
            else { oper2.Oper_ID = 0; }
            if (textBoxNazwa.Text == "" || textBoxNazwa.Text == null) { label3.Text = "Podaj login"; return; }
            if (textBoxNazwa.Text.Length < 1 || textBoxNazwa.Text.Length > 50) { label3.Text = "Błędna długość loginu"; return; }
            oper2.Oper_Login = textBoxNazwa.Text;
            oper2.Oper_Password = textBoxhaslo.Text;
            oper2.Oper_Type = checkBoxAdmin.Checked ? 0 : 1;
            var a = oper.modyfikacjaOperatora(oper2);
            label3.Text = komunikaty.komunikat[a.Item1];
            oper.Oper_ID = a.Item2;
        }
    }
}
