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
    public partial class OknoStworzeniaAktora : Form
    {
        line_up lu;

        public OknoStworzeniaAktora()
        {
            InitializeComponent();
        }
        public void ustawienieID(int id)
        {
            if (id > 0)
            {
                lu = Program.baza.pobranieAktora(id);
                tb_imie.Text = lu.LU_Name;
                tb_kraj.Text = lu.LU_Country;
                tb_nazwisko.Text = lu.LU_Surname;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tb_nazwisko.Text == "" || tb_nazwisko == null)
            {
                info.Text = "Aktor musi mieć nazwisko";
                return;
            }
            if(tb_imie.Text == "" || tb_imie == null)
            {
                info.Text = "Aktor musi mieć imie";
                return;
            }
            if (tb_kraj.Text == "" || tb_kraj == null)
            {
                info.Text = "Aktor musi mieć kraj";
                return;
            }
            lu.LU_Surname = tb_nazwisko.Text;
            lu.LU_Name = tb_imie.Text;
            lu.LU_Country = tb_kraj.Text;
            var a = Program.baza.dodajAktora(lu);
            lu.LU_ID = a.Item2;
            info.Text = komunikaty.komunikat[a.Item1];
        }
    }
}
