using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class Okno_ustawien : Form
    {
        public Okno_ustawien()
        {
            InitializeComponent();
        }

        private void textBox_okno_ustawien_serwer_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_okno_ustawien_baza_danych_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox_okno_ustawien_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_okno_ustawien_haslo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_okno_ustawien_zapisz_Click(object sender, EventArgs e)
        {
            string serwer = textBox_okno_ustawien_serwer.Text;
            //textBox_okno_ustawien_login.Text = link;
            string baza_danych = textBox_okno_ustawien_baza_danych.Text;

            string haslo = textBox_okno_ustawien_haslo.Text;
            string login = textBox_okno_ustawien_login.Text;



        }

        private void label_login_Click(object sender, EventArgs e)
        {

        }

        private void label_haslo_Click(object sender, EventArgs e)
        {

        }
    }
}
