using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kino;

namespace Projekt_kino
{
    public partial class Okno_ustawien : Form
    {
        kinoDB baza = new kinoDB();

        public Okno_ustawien()
        {
            InitializeComponent();
            if (!baza.PolaczenieDoBazyZRejestru())
            {
                btn_ustawienia_zamknij.Enabled = false;
            }
            textBox_okno_ustawien_baza_danych.Text = baza.baza_danych;
            textBox_okno_ustawien_haslo.Text = baza.haslo;
            textBox_okno_ustawien_login.Text = baza.login;
            textBox_okno_ustawien_serwer.Text = baza.serwer;
            checkBox_metoda_logowania.Checked = baza.loginmethod;
        }

        private void checkBox_metoda_logowania_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_metoda_logowania.Checked == true)
            {
                label_login.Visible = false;
                label_haslo.Visible = false;
                textBox_okno_ustawien_login.Visible = false;
                textBox_okno_ustawien_haslo.Visible = false;
            }
            else
            {
                label_login.Visible = true;
                label_haslo.Visible = true;
                textBox_okno_ustawien_login.Visible = true;
                textBox_okno_ustawien_haslo.Visible = true;
            }
        }

        private void button_okno_ustawien_zapisz_Click(object sender, EventArgs e)
        {
            if (sprawdzenie_danych())
            {
                string serwer = textBox_okno_ustawien_serwer.Text;
                string baza_danych = textBox_okno_ustawien_baza_danych.Text;
                string haslo = textBox_okno_ustawien_haslo.Text;
                string login = textBox_okno_ustawien_login.Text;
                bool metodaLogowania = checkBox_metoda_logowania.Checked;
                bool poprawnoscLogowania = baza.ConnectionString(serwer, metodaLogowania, baza_danych, login, haslo);
                Label_info.Text = poprawnoscLogowania ? "Połączenie nawiązane poprawnie" : "Błąd połaczenia";
                if (poprawnoscLogowania)
                {
                    btn_ustawienia_zamknij.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sprawdzenie_danych())
            {
                string serwer = textBox_okno_ustawien_serwer.Text;
                string baza_danych = textBox_okno_ustawien_baza_danych.Text;
                string haslo = textBox_okno_ustawien_haslo.Text;
                string login = textBox_okno_ustawien_login.Text;
                bool metodaLogowania = checkBox_metoda_logowania.Checked;
                bool poprawnoscLogowania = baza.ConnectionString(serwer, metodaLogowania, baza_danych, login, haslo);
                Label_info.Text = poprawnoscLogowania ? "Połączenie nawiązane poprawnie" : "Błąd połaczenia";
            }
        }

        private void btn_ustawienia_skrypty_Click(object sender, EventArgs e)
        {
            if(baza.PolaczenieDoBazyZRejestru()) {
                Label_info.Text = baza.CreateTable();
            }
        }

        private bool sprawdzenie_danych()
        {
            bool poprawneDane = true;
            string serwer = textBox_okno_ustawien_serwer.Text;
            if (serwer == "")
            {
                Label_info.Text = "Nie podano nazwy serwera";
                poprawneDane = false;
            }
            string baza_danych = textBox_okno_ustawien_baza_danych.Text;
            if (baza_danych == "")
            {
                Label_info.Text = "Nie podano nazwy bazy danych";
                poprawneDane = false;
            }
            string haslo = textBox_okno_ustawien_haslo.Text;
            string login = textBox_okno_ustawien_login.Text;
            if (login == "" && textBox_okno_ustawien_login.Visible == true)
            {
                Label_info.Text = "Nie podano nazwy użytkownika";
                poprawneDane = false;
            }
            return poprawneDane;
        }
    }
}
