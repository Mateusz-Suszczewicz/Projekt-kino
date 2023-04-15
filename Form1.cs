using kino;
using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;
using System.Data;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Projekt_kino
{
    public partial class Form1 : Form
    {
        kinoDB baza = new kinoDB();
        bool modyfikacja_hasla = false;

        public Form1()
        {
            InitializeComponent();
            if (!baza.PolaczenieDoBazyZRejestru())
            {
                Okno_ustawien okno_Ustawien = new Okno_ustawien();
                DialogResult dr = okno_Ustawien.ShowDialog(this);
            }
            customizeDesign();
        }

        private void HidePanels(ControlCollection controls)
        {
            // wywo³anie jednej funckji spokowuej schowanie wszystkich paneli oprócz menu po prawej
            foreach (Control c in controls)
            {
                if (c != panel_menu_right && c is Panel)
                {
                    c.Visible = false;
                }
            }
        }

        private void customizeDesign()
        {
            panel_do_przycisku_konto.Visible = false;
            panel_logowanie.Visible = false;
            panel_rejestracja.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
        }

        private void hideSubMenu()
        {
            // == a nie = w ifie
            if (panel_do_przycisku_konto.Visible == true)
            {
                panel_do_przycisku_konto.Visible = false;
            }
            // mo¿esz dla prostych warunków zrobiæ coœ takiego
            //panel_do_przycisku_konto.Visible = panel_do_przycisku_konto.Visible == true ? false : true;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
                przycisk_konto.Text = "Konto";
            }
            else
            {
                subMenu.Visible = false;
                przycisk_konto.Text = "Konto ••";
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel_logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void przycisk_konto_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_do_przycisku_konto);
            HidePanels((ControlCollection)this.Controls);
        }

        private void Konto_subMenu_rejestracja_Click(object sender, EventArgs e)
        {
            panel_do_przycisku_konto.Visible = false;
            if (panel_rejestracja.Visible)
                panel_rejestracja.Visible = false;
            else panel_rejestracja.Visible = true;
            label5.Visible = false;
        }

        private void Konto_subMenu_logowanie_Click(object sender, EventArgs e)
        {
            panel_do_przycisku_konto.Visible = false;
            if (panel_logowanie.Visible)
                panel_logowanie.Visible = false;
            else panel_logowanie.Visible = true;
            label7.Visible = false;

        }

        private void ustawienia_Click(object sender, EventArgs e)
        {
            Okno_ustawien okno_Ustawien = new Okno_ustawien();
            DialogResult dr = okno_Ustawien.ShowDialog(this);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel_menu_right_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel_rejestracja_zaloguj_sie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_rejestracja.Visible = false;
            panel_logowanie.Visible = true;
        }

        private void panel_logowanie_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel_logowanie_zarejestruj_sie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_logowanie.Visible = false;
            panel_rejestracja.Visible = true;
            button_rejestracja_zaloz_konto.Text = "Zmodyfikuj has³o";
            modyfikacja_hasla = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox2.Text;
            string password = textBox3.Text;
            Operator oper = new Operator();
            if (login != "")
            {
                var a = oper.logowanie(login, password);
                if (a)
                {
                    panel_logowanie.Visible = false;
                    aktualny_czas.Text = $"Willkommen! {oper.GetOperLogin()}";
                    textBox3.Text = "";
                }
                else
                {
                    label7.Text = "B³êdne logowanie";
                }
            }
            else
            {
                label7.Text = "login nie mo¿e byæ pusty";
            }
            label7.Visible = true;
        }

        private void button_rejestracja_zaloz_konto_Click(object sender, EventArgs e)
        {
            if (textBox_rejestracja_haslo_1.Text == textBox_rejestracja_haslo_2.Text && textBox_rejestracja_login.Text != "")
            {
                string pass = textBox_rejestracja_haslo_1.Text;
                string login = textBox_rejestracja_login.Text;
                Operator oper = new Operator();
                if (!modyfikacja_hasla)
                {
                    label5.Text = oper.dodanienowegoOperatora(login, pass, 1);
                }
                else
                {
                    Operator a = baza.GetOperators(login);
                    if(a != null)
                    {
                        label5.Text = oper.modyfikacjaOperatora(a.GetOperId(), null, pass);
                    }
                }
            }
            else
            {
                label5.Text = "B³êdne dane";
            }
            label5.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button_rejestracja_zaloz_konto.Text = "Zmodyfikuj has³o";
            panel_logowanie.Visible = false;
            panel_rejestracja.Visible = true;
            modyfikacja_hasla = true;
        }
    }
}