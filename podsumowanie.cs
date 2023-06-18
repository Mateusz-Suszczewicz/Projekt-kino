using kino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Projekt_kino
{
    public partial class podsumowanie : Form
    {
        Filmy Film;
        List<miejsce> listaMiejsc = new List<miejsce>();
        DataGridView koszyk = new DataGridView();
        DataGridView tab = new DataGridView();

        public podsumowanie()
        {
            InitializeComponent();
            button2.Visible = false;
        }

        public void zaladowanie_danych(List<int> listaMijesc, Filmy film)
        {
            Film = film;
            foreach (int i in listaMijesc)
            {
                miejsce miejsce = new miejsce(i);
                listaMiejsc.Add(miejsce);
            }
            buttons_loads();
            odswierzenieKoszyka();
        }

        private void buttons_loads()
        {
            label_pods_tytul.Text = "      Tytuł: " + Film.Film_Title;
            label_pods_tytul.ForeColor = Color.Black;
            label_pods_tytul.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_tytul.Location = new Point(50, 30);

            label_pods_dzien.Text = "     Dzień: " + Film.seanses[0].getDataEmisji();
            label_pods_dzien.ForeColor = Color.Black;
            label_pods_dzien.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_dzien.Location = new Point(50, 80);

            label_pods_godzina.Text = "Godzina: " + Film.seanses[0].getGodzinaEmisji();
            label_pods_godzina.ForeColor = Color.Black;
            label_pods_godzina.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_godzina.Location = new Point(50, 130);

            label_pods_sala.Text = "       Sala: " + Film.seanses[0].sal.SR_Nr;
            label_pods_sala.ForeColor = Color.Black;
            label_pods_sala.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_sala.Location = new Point(50, 180);

            label_pods_miejsca.Text = "  Miejsca:";
            label_pods_miejsca.ForeColor = Color.Black;
            label_pods_miejsca.Font = new Font("Arial", 14, FontStyle.Bold);
            label_pods_miejsca.Location = new Point(50, 230);

            label_koszyk.Text = "Koszyk:";
            label_koszyk.ForeColor = Color.Black;
            label_koszyk.Font = new Font("Arial", 14, FontStyle.Bold);
            label_koszyk.Location = new Point(750, 30);

            #region tabela biletów

            tab.DataSource = null;
            tab.Rows.Clear();
            tab.Columns.Clear();



            DataGridViewTextBoxColumn lp = new DataGridViewTextBoxColumn();
            //lp.ValueType = typeof(int);
            lp.Name = "Bilet";
            lp.HeaderText = "Bilet";
            lp.Width = 100;
            lp.ReadOnly = true;
            tab.Columns.Add(lp);

            DataGridViewTextBoxColumn row = new DataGridViewTextBoxColumn();
            row.Name = "Rząd";
            row.HeaderText = "Rząd";
            row.Width = 120;
            row.ReadOnly = true;
            tab.Columns.Add(row);

            DataGridViewTextBoxColumn number = new DataGridViewTextBoxColumn();
            number.Name = "Numer";
            number.HeaderText = "Number";
            number.Width = 120;
            number.ReadOnly = true;
            tab.Columns.Add(number);

            DataGridViewCheckBoxColumn type = new DataGridViewCheckBoxColumn();
            type.Name = "Rodzaj";
            type.HeaderText = "Ulogwy";
            type.Width = 120;
            tab.Columns.Add(type);

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            //lp.ValueType = typeof(int);
            id.Name = "id";
            id.HeaderText = "id";
            id.Width = 100;
            id.Visible = false;
            tab.Columns.Add(id);


            #endregion

            #region tabela_koszyk

            koszyk.DataSource = null;
            koszyk.Rows.Clear();
            koszyk.Columns.Clear();

            DataGridViewTextBoxColumn koszyk_type = new DataGridViewTextBoxColumn();
            koszyk_type.Name = "Typ biletu";
            koszyk_type.HeaderText = "Typ biletu";
            koszyk_type.Width = 100;
            koszyk_type.ReadOnly = true;
            koszyk.Columns.Add(koszyk_type);

            DataGridViewTextBoxColumn koszyk_ilosc = new DataGridViewTextBoxColumn();
            koszyk_ilosc.Name = "Ilość";
            koszyk_ilosc.HeaderText = "Ilość";
            koszyk_ilosc.Width = 60;
            koszyk_ilosc.ReadOnly = true;
            koszyk.Columns.Add(koszyk_ilosc);

            DataGridViewTextBoxColumn koszyk_kwota = new DataGridViewTextBoxColumn();
            koszyk_kwota.Name = "Kwota";
            koszyk_kwota.HeaderText = "Kwota";
            koszyk_kwota.Width = 100;
            koszyk_kwota.ReadOnly = true;
            koszyk.Columns.Add(koszyk_kwota);

            koszyk.AllowUserToResizeColumns = false;
            koszyk.RowHeadersVisible = false;
            koszyk.BackgroundColor = Color.White;
            koszyk.Size = new Size(265, 80);
            koszyk.AllowUserToResizeRows = false;
            koszyk.Location = new Point(600, 80);


            this.Controls.Add(koszyk);

            tab.AllowUserToResizeColumns = false;
            tab.RowHeadersVisible = false;
            tab.BackgroundColor = Color.White;

            tab.Size = new Size(465, 200);

            int numer_biletu = 1;
            foreach (miejsce i in listaMiejsc)
            {
                DataGridViewRow ROW = (DataGridViewRow)tab.Rows[0].Clone();
                ROW.Cells[0].Value = numer_biletu;
                ROW.Cells[1].Value = (i.Seat_Row - 150) / 70;
                ROW.Cells[2].Value = (i.Seat_Nr - 450) / 55;
                ROW.Cells[4].Value = i.Seat_ID.ToString();

                tab.Rows.Add(ROW);
                numer_biletu++;
            }
            tab.AllowUserToAddRows = false;
            tab.AllowUserToResizeRows = false;
            tab.Location = new Point(50, 300);
            tab.CellClick += tab_CellContentClick;
            this.Controls.Add(tab);

            #endregion
            koszyk.AllowUserToAddRows = false;
        }

        private void button_zatwierdz_Click(object sender, EventArgs e)
        {
            zakup_biletu zak = new zakup_biletu();
            this.Hide();
            zak.ShowDialog();
            zak.Show();

        }

        private void tab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            odswierzenieKoszyka();

        }

        private void odswierzenieKoszyka()
        {
            koszyk.AllowUserToAddRows = true;
            koszyk.Rows.Clear();
            decimal kosztUlgowy = 0;
            int ilosculgowy = 0;
            decimal kosztNormalny = 0;
            int iloscNormalny = 0;

            foreach (DataGridViewRow wiersz in tab.Rows)
            {
                DataGridViewCheckBoxCell chkchecking = wiersz.Cells[3] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chkchecking.Value) == true)
                {
                    kosztUlgowy += Program.cenaUlgowa;
                    ilosculgowy++;
                }
                else
                {
                    kosztNormalny += Program.cenaNormalna;
                    iloscNormalny++;
                }

            }
            DataGridViewRow ROW = (DataGridViewRow)koszyk.Rows[0].Clone();
            ROW.Cells[0].Value = "Normalny";
            ROW.Cells[1].Value = iloscNormalny;
            ROW.Cells[2].Value = kosztNormalny;

            koszyk.Rows.Add(ROW);

            DataGridViewRow ROW1 = (DataGridViewRow)koszyk.Rows[0].Clone();
            ROW1.Cells[0].Value = "Ulgowy";
            ROW1.Cells[1].Value = ilosculgowy;
            ROW1.Cells[2].Value = kosztUlgowy;

            koszyk.Rows.Add(ROW1);
            koszyk.AllowUserToAddRows = false;
        }

        private void podsumowanie_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            kinoDB baza = new kinoDB(true);
            foreach (DataGridViewRow i in tab.Rows)
            {
                foreach (miejsce a in listaMiejsc)
                {
                    if (a.Seat_ID.ToString() == i.Cells[4].Value.ToString())
                    {
                        var info = baza.kupnoBiletu(a, Film, Convert.ToBoolean(i.Cells[3].Value));
                        if (info.Item1 != 45)
                        {
                            flag = true;
                            label1.Text += komunikaty.komunikat[info.Item1];

                        }
                    }
                }
            }
            if (!flag)
            {
                label1.Text = "Zakupiono bilety";
            }
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
