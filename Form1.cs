using kino;
using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;
using System.Data;
using System;
using static System.Net.Mime.MediaTypeNames;


namespace Projekt_kino
{
    public partial class Form1 : Form
    {
        kinoDB a = new kinoDB();

        public Form1()
        {
            InitializeComponent();
            if (!a.ConnectionString("LAPTOP-VHVG8IJE", 1, "KINO", "sa", ""))
            {
                textBox1.Text = "nie dzia³a";
            }
            a.PolaczenieDoBazyZRejestru();


            customizeDesign();
        }
        private void customizeDesign()
        {
            panel_do_przycisku_konto.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panel_do_przycisku_konto.Visible == true)
            {
                panel_do_przycisku_konto.Visible = false;
            }
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
        }

        private void Konto_subMenu_rejestracja_Click(object sender, EventArgs e)
        {

        }

        private void Konto_subMenu_logowanie_Click(object sender, EventArgs e)
        {

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
    }
}