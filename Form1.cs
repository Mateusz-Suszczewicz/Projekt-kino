using kino;
using Projekt_kino.Form_Konfiguracja;
using System.Windows.Forms;

namespace Projekt_kino
{
    public partial class Form1 : Form
    {
        kinoDB baza = new kinoDB(true);
        bool modyfikacja_hasla = false;
        bool log = false;

        public Form1()
        {
            InitializeComponent();
            reloadButton();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        public void logowanie()
        {
            log = true;
            reloadButton();
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

        private void przycisk_konto_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_do_przycisku_konto);
            HidePanels((ControlCollection)this.Controls);
        }

        private void Konto_subMenu_rejestracja_Click(object sender, EventArgs e)
        {
            reloadButton();
            panel_do_przycisku_konto.Visible = false;
            if (panel_rejestracja.Visible)
                panel_rejestracja.Visible = false;
            else panel_rejestracja.Visible = true;
            label5.Visible = false;
            przycisk_konto.Text = "Konto ••";
            button_rejestracja_zaloz_konto.Text = "Za³ó¿ konto";

        }

        private void Konto_subMenu_logowanie_Click(object sender, EventArgs e)
        {
            reloadButton();
            panel_do_przycisku_konto.Visible = false;
            if (panel_logowanie.Visible)
                panel_logowanie.Visible = false;
            else panel_logowanie.Visible = true;
            przycisk_konto.Text = "Konto ••";
            label7.Visible = false;

        }

        private void linkLabel_rejestracja_zaloguj_sie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reloadButton();
            panel_rejestracja.Visible = false;
            panel_logowanie.Visible = true;
        }

        private void linkLabel_logowanie_zarejestruj_sie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reloadButton();
            panel_logowanie.Visible = false;
            panel_rejestracja.Visible = true;
            button_rejestracja_zaloz_konto.Text = "Zmodyfikuj has³o";
            modyfikacja_hasla = false;
            button_rejestracja_zaloz_konto.Text = "Za³ó¿ konto";
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
                    Program.zalogowanyOperator = oper;
                    reloadButton();
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
            if (log)
            {
                this.Close();
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
                    oper.Oper_Login = login;
                    oper.Oper_Password = oper.encryptionPass(pass);
                    oper.Oper_Type = 1;
                    var a = baza.dodajOperatora(oper);
                    label5.Text = komunikaty.komunikat[a.Item1];
                }
                else
                {
                    oper = baza.GetOperators(login);
                    if (oper != null)
                    {
                        oper.Oper_Password = oper.encryptionPass(pass);
                        var b = baza.dodajOperatora(oper);
                        label5.Text = komunikaty.komunikat[b.Item1];
                    }
                }
            }
            else
            {
                label5.Text = "B³êdne dane";
            }
            label5.Visible = true;
            reloadButton();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reloadButton();
            button_rejestracja_zaloz_konto.Text = "Zmodyfikuj has³o";
            panel_logowanie.Visible = false;
            panel_rejestracja.Visible = true;
            modyfikacja_hasla = true;
        }

        private void przycisk_repertuar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            repertuar repertuar = new repertuar();
            repertuar.ShowDialog(this);
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kinoDB baza = new kinoDB(true);
            baza.aktualizacjaSeansów();
        }

        private void btn_konf_Click(object sender, EventArgs e)
        {
            OknoKonfiguracji ok = new OknoKonfiguracji();
            this.Hide();
            ok.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Okno_ustawien okno_Ustawien = new Okno_ustawien();
            DialogResult dr = okno_Ustawien.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.zalogowanyOperator = null;
            reloadButton();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void reloadButton()
        {
            aktualny_czas.Text = $"Witaj!\n";
            if (Program.zalogowanyOperator != null)
            {
                aktualny_czas.Text += $"{Program.zalogowanyOperator.Oper_Login}";
            }

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            ustawienia.Visible = false;
            btn_konf.Visible = false;

            textBox2.Text = "";
            textBox3.Text = "";
            textBox3.PasswordChar = '*';
            textBox_rejestracja_login.Text = "";
            textBox_rejestracja_haslo.Text = "";
            textBox_rejestracja_haslo_1.Text = "";
            textBox_rejestracja_haslo_2.Text = "";
            textBox_rejestracja_haslo_1.PasswordChar = '*';
            textBox_rejestracja_haslo_2.PasswordChar = '*';

            if (!baza.PolaczenieDoBazyZRejestru())
            {
                Okno_ustawien okno_Ustawien = new Okno_ustawien();
                DialogResult dr = okno_Ustawien.ShowDialog(this);

            }

            #region Logowanie w przypadku kupna biletu
            if (!log)
            {
                customizeDesign();
                baza.ustawienieCen();
            }

            if (log)
            {
                panel_logowanie.Visible = true;
            }
            #endregion

            // zalogowany operator (ka¿dy)
            if (Program.zalogowanyOperator != null)
            {
                button4.Visible = true;
            }

            // zalogowany Admin
            if (Program.zalogowanyOperator != null && Program.zalogowanyOperator.Oper_Type == 0)
            {
                btn_konf.Visible = true;
                button3.Visible = true;
            }
        }

    }
}